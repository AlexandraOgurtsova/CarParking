using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
            
        }
        

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            PasswordWork passwork = new PasswordWork();
             
            var regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
            var regex1 = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,20}(\s*)?$");

            DataBase bd = new DataBase();
            DataTable dt = bd.Select("users", "LoginUser", login.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Этот логин уже занят");
            }
            else
            {
                if (!(login.Text == "" || firstName.Text == "" || secondName.Text == "" || Mobile.Text == "" || Mail.Text == ""))
                {
                    if (regex1.IsMatch(Mobile.Text))
                    {
                        if (regex.IsMatch(password.Password))
                        {

                            string hash_password = passwork.HashPassword(password.Password);

                            DataBase DB = new DataBase();
                            SqlCommand command = new SqlCommand("insert into users(LoginUser, FirstName, SecondName, Mobile, Password, Mail, BitAdmin) values (@login, @firstname, @secondname, @mobile, @passvord, @mail, '0')", DB.GetConnection());

                            command.Parameters.Add("@login", SqlDbType.VarChar).Value = login.Text;
                            command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = firstName.Text;
                            command.Parameters.Add("@secondname", SqlDbType.VarChar).Value = secondName.Text;
                            command.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile.Text;
                            command.Parameters.Add("@passvord", SqlDbType.VarChar).Value = hash_password;
                            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = Mail.Text;

                            DB.openConnection();

                            if (command.ExecuteNonQuery() == 1)
                            {
                                DB.InsertIntoHistory("history", "Зарегистрирован пользователь " + login.Text + " ", DateTime.Now);
                                MessageBox.Show("Аккаунт был создан");
                                Window1 MVShow = new Window1();
                                MVShow.Show();
                                this.Close();


                            }
                            else
                                MessageBox.Show("Ошибка");

                            DB.closeConnection();

                        }
                        else
                        {
                            MessageBox.Show("Пароль должен содержать латинские буквы верхнего и нижнего регистра и хотя бы одну цифру");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Введите коректный номер мобильного телефона");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
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

        private void aotorization_Click(object sender, RoutedEventArgs e)
        {
            Window1 MVShow = new Window1();
            MVShow.Show();
            this.Close();
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
