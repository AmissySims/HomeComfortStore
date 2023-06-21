﻿using ComfortStoreLibrary.Models;
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

namespace Admin.Pages
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

            var use = App.db.User.ToList();
            use.Insert(0, new User() { FirstName = "Все" });
            UserCb.ItemsSource = use;
        }

        private void Refresh()
        {
            var users = UserCb.SelectedItem as User;
            var status = StatusCb.SelectedItem as OrdStatus;
            var ord = App.db.Order.ToList();

            if (users != null && users.Id != 0)
            {
                ord = ord.Where(x => x.UserId == users.Id).ToList();
            }

            if (status != null && status.Id != 0)
            {
                ord = ord.Where(x => x.OrdStatusId == status.Id).ToList();
            }

            OrdersList.ItemsSource = ord;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void StatusCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
