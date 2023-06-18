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

namespace HomeComfortStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void AccountBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UsersBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShipmentsBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrdersBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
