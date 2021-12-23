using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using System.Windows.Shapes;
using курсовой.Classes;

namespace курсовой.Windows_parking
{
    /// <summary>
    /// Логика взаимодействия для change_user.xaml
    /// </summary>
    public partial class change_user_password : Window
    {
        public change_user_password(string str)
        {
            InitializeComponent();

            log.Content += str;
        }



        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            var regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");

            PasswordWork passwork = new PasswordWork();

            CommandBD cbd = new CommandBD();

            CommandBD command = new CommandBD();
            DataTable table = command.Select("users", "LoginUser", log.Content.ToString());
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Этот логин не зарегистрирован");
            }
            else
            {

              if (!(old_password.Password == "" || new_password.Password == ""))
              {
                    if (!(passwork.HashToPassword(table.Rows[0]["Password"].ToString(), old_password.Password)))
                    {
                        MessageBox.Show("Невеправельный старый пароль");
                    }
                    else
                    {
                        if (regex.IsMatch(new_password.Password))
                        {
                            string hash_password = passwork.HashPassword(new_password.Password);

                            cbd.UpdateUserParametr("Password", hash_password, "LoginUser", log.Content.ToString());

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Новый пароль должен содержать латинские буквы верхнего и нижнего регистра и хотя бы одну цифру");
                        }

                    }
              }
              else
              {
                MessageBox.Show("Заполните все поля");
              }

            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

    }
}

