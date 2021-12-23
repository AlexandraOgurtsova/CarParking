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

namespace курсовой.Windows_parking
{
    /// <summary>
    /// Логика взаимодействия для change_admin.xaml
    /// </summary>
    public partial class change_admin : Window
    {
        public change_admin()
        {
            InitializeComponent();
            list_box();

        }

        public void list_box()
        {
            DataBase DB = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT Change From change_admin", DB.GetConnection());

            SqlDataReader myreader;
            try
            {
                DB.openConnection();
                myreader = command1.ExecuteReader();
                while (myreader.Read())
                {

                    listBox.Items.Insert(0, myreader["Change"].ToString());

                }
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (!(admin1.Text == "" || admin2.Text == ""))
            {

                DataBase DB = new DataBase();

                SqlCommand command = new SqlCommand("insert into change_admin(Change) values(@parametr)", DB.GetConnection());

                command.Parameters.Add("@parametr", SqlDbType.VarChar).Value = admin1.Text +" сдал смену, "+admin2.Text+" принял смену " + DateTime.Now.ToString();

                DB.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    DB.InsertIntoHistory("history", " " + admin1.Text + " сдал смену " + admin2.Text + " ", DateTime.Now);
                    MessageBox.Show("Смена сдана");
                }
                else
                    MessageBox.Show("Ошибка");



                DB.closeConnection();

                list_box();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
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
