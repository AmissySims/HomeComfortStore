using ComfortStoreLibrary.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Windows;
using System.Windows.Input;

namespace Admin.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCategory.xaml
    /// </summary>
    public partial class AddEditCategory : Window
    {
        CategoryProduct contextCat;
        DbPropertyValues oldValues;
        public AddEditCategory(CategoryProduct categoryProduct)
        {
            InitializeComponent();
            contextCat = categoryProduct;
            DataContext = contextCat;
            if(contextCat.Id != 0)
            {
                oldValues = App.db.Entry(contextCat).CurrentValues.Clone();
            }

        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }
        private void TitleTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(contextCat.Title))
                {
                    MessageBox.Show("Заполните поле названия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if(contextCat.Id == 0)
                    {
                        App.db.CategoryProduct.Add(contextCat);
                    }
                    App.db.SaveChanges();
                    MessageBox.Show("Сохранено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (oldValues != null)
                {
                    App.db.Entry(contextCat).CurrentValues.SetValues(oldValues);
                }
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
