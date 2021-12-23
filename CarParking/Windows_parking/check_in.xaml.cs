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
    /// Логика взаимодействия для check_in.xaml
    /// </summary>
    public partial class check_in : Window
    {
        public check_in(string number_)
        {
            InitializeComponent();
            carcombobox();

            number_on_parking.Text += number_;

        }

        public void carcombobox()
        {
            DataBase DB = new DataBase();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT Number From cars ", DB.GetConnection());

            SqlDataReader myreader;
            try
            {
                DB.openConnection();
                myreader = command1.ExecuteReader();
                while (myreader.Read())
                {
                    string snumber = myreader.GetString(0);
                    car.Items.Add(snumber);
                }
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void car_LostFocus(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DB.openConnection();

            SqlCommand command = new SqlCommand("SELECT * From place WHERE Car = '" + car.Text + "' and Status_='занято' ", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данная машина уже находится на стоянке");
            }

            DataBase DB1 = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter1 = new SqlDataAdapter();

            string item = (string)car.SelectedItem;

            SqlCommand command1 = new SqlCommand("SELECT users.SecondName, users.Mobile From cars inner join users on cars.Owner = users.IdUser where Number = '" + item + "'", DB1.GetConnection());

            SqlDataReader myreader;
            try
            {
                DB1.openConnection();
                myreader = command1.ExecuteReader();
                while (myreader.Read())
                {
                    user.Text = myreader.GetString(0);
                    mobile.Text = myreader.GetString(1);
                }
                DB1.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string number_ = car.Text; 
            string owner_ = user.Text;
            string mobile_ = mobile.Text;

            DataBase DB1 = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter1 = new SqlDataAdapter();

            DB1.openConnection();

            SqlCommand command2 = new SqlCommand("SELECT * From place WHERE Car = '" + car.Text + "' and Status_='занято' ", DB1.GetConnection());

            adapter1.SelectCommand = command2;
            adapter1.Fill(table1);

            if (table1.Rows.Count > 0)
            {
                MessageBox.Show("Данная машина уже находится на стоянке");
            }

            else
            {
                DataBase DB = new DataBase();

                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DB.openConnection();

                SqlCommand command1 = new SqlCommand("SELECT * From cars inner join users on cars.Owner=users.IdUser WHERE cars.Number = '" + car.Text + "' AND users.SecondName = '" + user.Text + "' AND users.Mobile='" + mobile.Text + "'", DB.GetConnection());

                adapter.SelectCommand = command1;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    if (!(number_on_parking.Text == "" || car.Text == "" || date_time.Text == "" || user.Text == "" || type.Text == "" || period.Text == ""))
                    {

                        SqlCommand command = new SqlCommand("declare @t int; set @t=(select IdUser from users where SecondName='" + user.Text + "' and Mobile='" + mobile.Text + "');  insert into place(Number, Car, Date_beginning, Owner, Status_, Type_of_setting, Production_period) values (@Number, @Car, @Date_beginning, @t, 'Занято', @Type_of_setting, @Production_period)", DB.GetConnection());

                        command.Parameters.Add("@Number", SqlDbType.VarChar).Value = number_on_parking.Text;
                        command.Parameters.Add("@Car", SqlDbType.VarChar).Value = car.Text;
                        command.Parameters.Add("@Date_beginning", SqlDbType.VarChar).Value = date_time.Text;
                        command.Parameters.Add("@Type_of_setting", SqlDbType.VarChar).Value = type.Text;
                        command.Parameters.Add("@Production_period", SqlDbType.VarChar).Value = period.Text;

                        DB.openConnection();

                        if (command.ExecuteNonQuery() == 1)
                        {
                            DB.InsertIntoHistory("history", "Машина " + car.Text + " помещена на стоянку", DateTime.Now);

                            MessageBox.Show("Машина помещена на стоянку");

                            admin MVShow = new admin();
                            MVShow.Show();
                            this.Close();


                        }
                        else
                        {
                            MessageBox.Show("error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля");
                    }
                }

                else
                {
                    add_car MVShow = new add_car(number_, owner_, mobile_);
                    MVShow.Show();
                }
                DB.closeConnection();
            }

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            date_time.Text = DateTime.Now.ToString();
        }

        private void car_LostFocus(object sender,EventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            string item = (string)car.SelectedItem;

            SqlCommand command1 = new SqlCommand("SELECT users.SecondName, users.Mobile From cars inner join users on cars.Owner = users.IdUser where Number = '"+item+"'", DB.GetConnection());

            SqlDataReader myreader;
            try
            {
                DB.openConnection();
                myreader = command1.ExecuteReader();
                while (myreader.Read())
                {
                    user.Text = myreader.GetString(0);
                    mobile.Text = myreader.GetString(1);
                }
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void date_time_TextChanged(object sender, TextChangedEventArgs e)
        {
            date_time.Text = DateTime.Now.ToString();
        }

        private void userLostFocus(object sender, EventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand com = new SqlCommand("select Mobile from users where SecondName='"+ user.Text+ "'", DB.GetConnection());

            adapter.SelectCommand = com;
            adapter.Fill(table);

            DB.openConnection();

            SqlDataReader reader1 = com.ExecuteReader();
            while (reader1.Read()) // если есть данные
            {
                string mob = reader1.GetString(0);
                mobile.Text = mob;
                
            }
            DB.closeConnection();


        }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
            if (type.Text == "сутки")
            {
                int pr1 = Convert.ToInt32(period.Text);
                int sum1;
                sum1 = pr1 * 10;
                summa.Text = Convert.ToString(sum1);
            }
                
        }

        private void period_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (type.Text == "сутки")
            {
                int pr1 = Convert.ToInt32(period.Text);
                int sum1;
                sum1 = pr1 * 10;
                summa.Text = Convert.ToString(sum1);
            }
            else
            {
                double pr2 = Convert.ToDouble(period.Text);
                double sum1;
                sum1 = pr2 * 0.5;
                summa.Text = Convert.ToString(sum1);
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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            admin MVShow = new admin();
            MVShow.Show();
            this.Close();
        }

    }
}
