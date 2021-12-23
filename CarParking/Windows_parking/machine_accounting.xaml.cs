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
    /// Логика взаимодействия для machine_accounting.xaml
    /// </summary>
    public partial class machine_accounting : Window
    {
        public machine_accounting()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * From cars ", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataGrid.ItemsSource = table.DefaultView;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            admin MWShow = new admin();
            MWShow.Show();
            this.Close();
        }

        private void doubleclick(object sender, MouseButtonEventArgs e)
        {
            if (DataGrid.SelectedItems.Count == 0) return;

            string id_user = ((DataRowView)DataGrid.SelectedItems[0]).Row["Owner"].ToString();

            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("select * from users where IdUser=" + id_user + "", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            string surname = table.Rows[0]["SecondName"].ToString();
            string mobile = table.Rows[0]["Mobile"].ToString();


            string info_user = surname + ", " + mobile;

            MessageBox.Show(info_user);

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void history_Click(object sender, RoutedEventArgs e)
        {
            history_parking MWShow = new history_parking();
            MWShow.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table1 = new DataTable();

            string number = ((DataRowView)DataGrid.SelectedItems[0]).Row["Number"].ToString();

            SqlCommand command1 = new SqlCommand("SELECT * from place where Car='" + number + "' ", DB.GetConnection());

            DB.openConnection();

            SqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                MessageBox.Show("В данное время изменить данные нельзя, попробуйте снова, когда машина данного пользователя покинет стоянку");

                DB.closeConnection();
            }
            else
            {
                DataBase DB1 = new DataBase();

                DataTable table = new DataTable();

                if (DataGrid.SelectedItems.Count == 0) return;

                SqlCommand com1 = new SqlCommand("DELETE FROM cars WHERE Number='" + number + "'", DB1.GetConnection());

                DB1.openConnection();

                if (com1.ExecuteNonQuery() == 1)
                {

                    DB1.InsertIntoHistory("history", "Удалена машина " + number + " ", DateTime.Now);
                    MessageBox.Show("Машина удалена");
                }
                else
                    MessageBox.Show("Ошибка");

                DB1.closeConnection();

                DataBase DB2 = new DataBase();

                SqlDataAdapter adapter2 = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT * From cars ", DB2.GetConnection());

                adapter2.SelectCommand = command;
                adapter2.Fill(table);
                DataGrid.ItemsSource = table.DefaultView;
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

