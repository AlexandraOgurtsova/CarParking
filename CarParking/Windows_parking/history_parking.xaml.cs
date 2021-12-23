using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using курсовой.Classes;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class history_parking : Window
    {
        public history_parking()
        {
            InitializeComponent(); 
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * From history", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataGrid.ItemsSource = table.DefaultView;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            admin MWShow = new admin();
            MWShow.Show();
            this.Close();
        }


        private void controlUsers_Click(object sender, RoutedEventArgs e)
        {
            user_management MWShow = new user_management();
            MWShow.Show();
            this.Close();
        }

        private void controlCars_Click(object sender, RoutedEventArgs e)
        {
            machine_accounting MWShow = new machine_accounting();
            MWShow.Show();
            this.Close();
        }

        private void clean_Click(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            SqlCommand command = new SqlCommand("Delete From history", DB.GetConnection());

            DB.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("История очищена");
            }  
            else
            {
                MessageBox.Show("Ошибка");
            }
            DB.closeConnection();

            DataBase DB1 = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT * From history", DB1.GetConnection());

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            DataGrid.ItemsSource = table.DefaultView;
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
