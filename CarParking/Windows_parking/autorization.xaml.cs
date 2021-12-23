using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void autorizationButton_Click(object sender, RoutedEventArgs e)
        {

            if (login.Text != "" && password.Password != "")
            {
                PasswordWork passwork = new PasswordWork();
                CommandBD cbd = new CommandBD();
                DataTable dt = cbd.Select("users", "LoginUser", login.Text);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Этот логин не зарегистрирован");
                }
                else
                {
                    if (!(passwork.HashToPassword(dt.Rows[0]["Password"].ToString(), password.Password)))
                        MessageBox.Show("Неверный пароль");
                    else
                    {
                    
                        if (dt.Rows[0]["BitAdmin"].ToString() == "0")
                        {

                            string loginUser = login.Text;
                            user MWShow = new user(loginUser);
                            MWShow.Show();
                            this.Close();
                        }
                        else
                        {
                            
                            admin MWShow = new admin();
                            MWShow.Show();
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите и логин, и пароль");
            }
        }
        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            registration MVShow = new registration();
            MVShow.Show();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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
       
    

