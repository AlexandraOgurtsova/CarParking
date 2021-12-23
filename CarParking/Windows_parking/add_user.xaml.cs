using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для add_user.xaml
    /// </summary>
    public partial class add_user : Window
    {
        public add_user(string owner_, string mobile_)
        {
            InitializeComponent();
            SecondName.Text += owner_;
            Mobile.Text += mobile_;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!(FirstName.Text == "" || SecondName.Text == "" || Mobile.Text == ""))
            {

                DataBase DB = new DataBase();
                SqlCommand command = new SqlCommand("insert into users(FirstName, SecondName, Mobile) values (@firstname, @secondname, @mobile)", DB.GetConnection());

                command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = FirstName.Text;
                command.Parameters.Add("@secondname", SqlDbType.VarChar).Value = SecondName.Text;
                command.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile.Text;

                DB.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Пользователь добавлен");
                    this.Close();
                    DB.InsertIntoHistory("history", "Добавлен владелец машины " + SecondName.Text + " ", DateTime.Now);
                }
                else
                    MessageBox.Show("Ошибка");

                DB.closeConnection();
            }
            else
            {
                MessageBox.Show("Поля не заполнены");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
