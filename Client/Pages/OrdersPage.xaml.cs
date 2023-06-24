using Client.Windows;
using ComfortStoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            var stat = App.db.OrdStatus.ToList();
            stat.Insert(0, new OrdStatus() { Title = "Все" });
            StatusCb.ItemsSource = stat;
        }

        private void Refresh()
        {
            
            var status = StatusCb.SelectedItem as OrdStatus;
            var ord = App.db.Order.Where(x => x.UserId == AccountUser.AuthUser.Id).ToList();

            

            if (status != null && status.Id != 0)
            {
                ord = ord.Where(x => x.OrdStatusId == status.Id).ToList();
            }

            OrdersList.ItemsSource = ord;
        }
        private void CancelOrdBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selOrd = (sender as Button).DataContext as Order;
                selOrd.OrdStatusId = 7;
                MessageBox.Show("Отменено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                App.db.SaveChanges();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DoneOrdBt_Click(object sender, RoutedEventArgs e)
        {
            var selCode = (sender as Button).DataContext as Order;
            BarcodeWin orderEditWindow = new BarcodeWin(selCode);
            orderEditWindow.ShowDialog();
        }

        private void StatusCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
