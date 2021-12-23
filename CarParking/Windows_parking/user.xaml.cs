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
using курсовой.Windows_parking;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для user.xaml
    /// </summary>
    public partial class user : Window
    {
        public user(string loginUser)
        {
            InitializeComponent();
            LoginUser.Text += loginUser;
        }

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            

            SqlCommand command = new SqlCommand("SELECT * From users where users.LoginUser ='" + LoginUser.Text + "'", DB.GetConnection());

            SqlDataReader myreader;

            try
            {
                DB.openConnection();
                myreader = command.ExecuteReader();
                while (myreader.Read())
                {
                    FirstName.Text = myreader.GetString(2);
                    SecondName.Text = myreader.GetString(3);
                    Mobile.Text = myreader.GetString(4);
                    Mail.Text = myreader.GetString(6);
                }
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            adapter.SelectCommand = command;
            adapter.Fill(table);
            
        }

        private void cars_Loaded(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT Number, Mark, Colour, Type From cars inner join users on cars.Owner = users.IdUser where users.LoginUser ='"+LoginUser.Text+"'", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            cars.ItemsSource = table.DefaultView;
        }

        private void places_Loaded(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT Car, Number, Date_beginning, Type_of_setting, Production_period From place inner join users on place.Owner = users.IdUser where users.LoginUser = '" + LoginUser.Text + "'", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            places.ItemsSource = table.DefaultView;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void map_Click(object sender, RoutedEventArgs e)
        {
            parking_places MVShow = new parking_places(LoginUser.Text);
            MVShow.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Window1 MVShow = new Window1();
            MVShow.Show();
            this.Close();

        }


        private void change_login_click(object sender, RoutedEventArgs e)
        {
            
            change_user MVShow = new change_user(LoginUser.Text, LoginUser.Name.ToString());
            MVShow.Show();


        }

        private void change_name_click(object sender, RoutedEventArgs e)
        {
            change_user MVShow = new change_user(FirstName.Text, FirstName.Name.ToString());
            MVShow.Show();


        }

        private void change_surname_click(object sender, RoutedEventArgs e)
        {
            change_user MVShow = new change_user(SecondName.Text, SecondName.Name.ToString());
            MVShow.Show();
  

        }

        private void change_mobile_click(object sender, RoutedEventArgs e)
        {
            change_user MVShow = new change_user(Mobile.Text, Mobile.Name.ToString());
            MVShow.Show();


        }

        private void change_mail_click(object sender, RoutedEventArgs e)
        {
            change_user MVShow = new change_user(Mail.Text, Mail.Name.ToString());
            MVShow.Show();

        }

        private void ch_password_Click(object sender, RoutedEventArgs e)
        {
            change_user_password MVShow = new change_user_password(LoginUser.Text);
            MVShow.Show();

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
