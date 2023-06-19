using ComfortStoreLibrary.Models;
using Microsoft.Win32;
using System;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;


namespace Admin.Pages.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        Product contextProd;
        Warehouse conWare;
        DbPropertyValues oldValues;
        public AddEditProductPage(Product prod)
        {
            InitializeComponent();
            CategoryCb.ItemsSource = App.db.CategoryProduct.ToList();
            contextProd = prod;
            DataContext = contextProd;
            if (contextProd.Id != 0)
            {
                oldValues = App.db.Entry(contextProd).CurrentValues.Clone();
            }
            Refresh();
        }
        public void Refresh()
        {
            ImageList.ItemsSource = contextProd.ProductPhoto.ToList();
        }
        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (contextProd.Id == 0)
                {
                    App.db.Product.Add(contextProd);
                    Warehouse warehouse = new Warehouse
                    {
                        ProductId = contextProd.Id,
                        Count = 0
                    };
                    App.db.Warehouse.Add(warehouse);

                }
                App.db.SaveChanges();
                MessageBox.Show("Сохранено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
           catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);;
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(oldValues != null)
                {
                    App.db.Entry(contextProd).CurrentValues.SetValues(oldValues);
                }
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog() { Multiselect  = true };
                if(dialog.ShowDialog().GetValueOrDefault())
                {
                    if(dialog.FileNames.Length > 0)
                    {
                        foreach(var item in dialog.FileNames)
                        {
                            contextProd.ProductPhoto.Add(new ProductPhoto()
                            {
                                Image = File.ReadAllBytes(item),
                                Product = contextProd
                            });

                        }
                        Refresh();
                        DataContext = null;
                        DataContext = contextProd;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selImage = ImageList.SelectedItem as ProductPhoto;
                if(selImage != null)
                {
                  
                    App.db.ProductPhoto.Remove(selImage);
                    App.db.SaveChanges();
                   
                }
                else
                {
                    MessageBox.Show("Выберите изображение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
