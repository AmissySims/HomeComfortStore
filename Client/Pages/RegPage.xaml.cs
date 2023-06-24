using ComfortStoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void FirstNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void LastNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void MiddleNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void EnterBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void RegBt_Click(object sender, RoutedEventArgs e)
        {
            var check = App.db.User.FirstOrDefault(x => x.Login == LoginTb.Text);
            try
            {
                if (string.IsNullOrWhiteSpace(PhoneTb.Text.Trim()))
                {
                    MessageBox.Show("Заполните поле телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if (Regex.IsMatch(PhoneTb.Text, @"^((\+?7|8)[ -]?)?([(]?\d[- ]?[()]?){10}$") && Regex.IsMatch(PhoneTb.Text, @"^(\+?7|8)?[\s(-]?[(-]?\d{3,4}[)-]?[ )-]?\d{2,7}[ -]?\d{2,4}[ -]?\d{0,2}$"))
                    {
                        if (string.IsNullOrWhiteSpace(LastNameTb.Text.Trim()))
                        {
                            MessageBox.Show("Заполните поле имени", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(LoginTb.Text.Trim()))
                        {
                            MessageBox.Show("Заполните поле логина", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(PasswordTb.Text.Trim()))
                        {
                            MessageBox.Show("Заполните поле пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(FirstNameTb.Text.Trim()))
                        {
                            MessageBox.Show("Заполните поле фамилии", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(MiddleNameTb.Text.Trim()))
                        {
                            MessageBox.Show("Заполните поле отчества", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            if (check == null)
                            {

                                User user = new User
                                {
                                    FirstName = FirstNameTb.Text,
                                    Password = PasswordTb.Text,
                                    LastName = LastNameTb.Text,
                                    MiddleName = MiddleNameTb.Text,
                                    RoleId = 2,
                                    Login = LoginTb.Text,
                                    Phone = PhoneTb.Text
                                };
                                App.db.User.Add(user);
                                App.db.SaveChanges();
                                MessageBox.Show("Регистрация выполнена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                LastNameTb.Text = "";
                                PasswordTb.Text = "";
                                FirstNameTb.Text = "";
                                LoginTb.Text = "";
                                MiddleNameTb.Text = "";
                                PhoneTb.Text = "";

                            }
                            else
                            {
                                MessageBox.Show("Пользователь уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                    }
                    else
                        MessageBox.Show($" Проверьте  телефон {PhoneTb.Text} на корректность", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
