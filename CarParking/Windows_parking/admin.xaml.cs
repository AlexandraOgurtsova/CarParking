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
using курсовой.Classes;
using курсовой.Windows_parking;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string str = "";
            parking_places MWShow = new parking_places(str);
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

            SqlCommand command = new SqlCommand("select * from users where IdUser="+id_user+"", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            string surname = table.Rows[0]["SecondName"].ToString();
            string mobile = table.Rows[0]["Mobile"].ToString();


            string info_user =surname + ", " + mobile;

            MessageBox.Show(info_user);

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * From place where Status_ = 'занято'", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataGrid.ItemsSource = table.DefaultView;
        }

        private void check_out_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItems.Count == 0) return;
            string number_car = ((DataRowView)DataGrid.SelectedItems[0]).Row["Car"].ToString();
            string owner_car = ((DataRowView)DataGrid.SelectedItems[0]).Row["Owner"].ToString();
            string place_car = ((DataRowView)DataGrid.SelectedItems[0]).Row["Number"].ToString();
            string time_begin = ((DataRowView)DataGrid.SelectedItems[0]).Row["Date_beginning"].ToString();
            string type_car = ((DataRowView)DataGrid.SelectedItems[0]).Row["Type_of_setting"].ToString();
            string period_begin = ((DataRowView)DataGrid.SelectedItems[0]).Row["Production_period"].ToString();

            check_out MVShow = new check_out(number_car, owner_car, place_car, time_begin, type_car, period_begin);
            MVShow.Show();
            this.Close();
        }

      

        private void map_parking_Click(object sender, RoutedEventArgs e)
        {
            string str = "1";
            parking_places MWShow = new parking_places(str);
            MWShow.Show();
            
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

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Window1 MWShow = new Window1();
            MWShow.Show();
            this.Close();
        }
        private void history_Click(object sender, RoutedEventArgs e)
        {
            history_parking MWShow = new history_parking();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            change_admin MWShow = new change_admin();
            MWShow.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Адрес автостоянки: г. Орша ул.Молокова д.43  \nВладелец автостоянки: Огурцова А.А.\nТарифы: \n   Час - 50 копеек\n   Сутки - 10 рублей ");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
