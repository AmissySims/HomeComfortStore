using ComfortStoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace StoreKeeper.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            
        }

        private void Refresh()
        {

            
            var ord = App.db.Order.Where(z => z.DeliveryTypeId == 1 && z.DeliveryPoint.UserId == AccountUser.AuthUser.Id && z.OrdStatusId == 5).ToList();



            

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
            try
            {
                var selOrd = (sender as Button).DataContext as Order;
                selOrd.OrdStatusId = 6;
                MessageBox.Show("Выдано", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                App.db.SaveChanges();
                Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
