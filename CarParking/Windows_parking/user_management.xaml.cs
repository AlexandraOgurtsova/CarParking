using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    /// Логика взаимодействия для user_management.xaml
    /// </summary>
    public partial class user_management : Window
    {
        //users_context db;
        public user_management()
        {
            InitializeComponent();
        }


        public void clean()
        {
            login.Text = String.Empty;
            FirstName.Text = String.Empty;
            SecondName.Text = String.Empty;
            Mobile.Text = String.Empty;
            Mail.Text = String.Empty;
            password.Text = String.Empty;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * From users ", DB.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataGrid.ItemsSource = table.DefaultView;
        }

        private void delete_user_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItems.Count == 0) return;

            string user = ((DataRowView)DataGrid.SelectedItems[0]).Row["IdUser"].ToString();

            DataBase DB1 = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter1 = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT * from place where Owner=" + Convert.ToInt32(id.Content) + " ", DB1.GetConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            DB1.openConnection();

            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.HasRows) // если есть данные
            {
                MessageBox.Show("В данное время изменить данные нельзя, попробуйте позже, когда машина данного пользователя покинет стоянку");
                DB1.closeConnection();
            }
            else
            {

                DataBase DB = new DataBase();

                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DB.openConnection();

                SqlCommand command = new SqlCommand("SELECT * From cars WHERE Owner = '" + user + "' ", DB.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("На данного пользователя зарегестрирована машина, удаление невозможно");
                    clean();
                }

                else
                {
                    CommandBD cbd3 = new CommandBD();

                    cbd3.Delete("users", "IdUser", user);

                    DB.InsertIntoHistory("history", "Удален пользователь " + SecondName.Text + " ", DateTime.Now);
                    MessageBox.Show("Пользователь удален");

                }

                DB.closeConnection();
            }
            DataBase DB3 = new DataBase();

            SqlCommand command3 = new SqlCommand("SELECT * From users ", DB3.GetConnection());

            DataTable table3 = new DataTable();

            SqlDataAdapter adapter3 = new SqlDataAdapter();

            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);
            DataGrid.ItemsSource = table3.DefaultView;

         

        }

        private void new_user_Click(object sender, RoutedEventArgs e)
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
                if (!(login.Text == "" || FirstName.Text == "" || SecondName.Text == "" || Mobile.Text == "" || Mail.Text == ""))
                {
                    if (regex1.IsMatch(Mobile.Text))
                    {
                        if (regex.IsMatch(password.Text))
                        {

                            string hash_password = passwork.HashPassword(password.Text);

                            DataBase DB = new DataBase();
                            SqlCommand command = new SqlCommand("insert into users(LoginUser, FirstName, SecondName, Mobile, Password, Mail, BitAdmin) values (@login, @firstname, @secondname, @mobile, @passvord, @mail, '1')", DB.GetConnection());

                            command.Parameters.Add("@login", SqlDbType.VarChar).Value = login.Text;
                            command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = FirstName.Text;
                            command.Parameters.Add("@secondname", SqlDbType.VarChar).Value = SecondName.Text;
                            command.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile.Text;
                            command.Parameters.Add("@passvord", SqlDbType.VarChar).Value = hash_password;
                            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = Mail.Text;

                            DB.openConnection();

                            if (command.ExecuteNonQuery() == 1)
                            {
                                if (command.ExecuteNonQuery() == 1)
                                {
                                    DB.InsertIntoHistory("history", "Добавлен владелец машины " + SecondName.Text + " ", DateTime.Now);
                                    MessageBox.Show("Пользователь добавлен");
                                    clean();
                                }
                                else
                                    MessageBox.Show("Ошибка");

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

            DataBase DB1 = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter1 = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT * From users ", DB1.GetConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            DataGrid.ItemsSource = table1.DefaultView;

        }

 

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItems.Count == 0) return;

            string login_ =((DataRowView)DataGrid.SelectedItems[0]).Row["LoginUser"].ToString(); 

            if (!(login_ == "admin"))
            {
                login.Text = ((DataRowView)DataGrid.SelectedItems[0]).Row["LoginUser"].ToString();
                FirstName.Text = ((DataRowView)DataGrid.SelectedItems[0]).Row["FirstName"].ToString();
                SecondName.Text = ((DataRowView)DataGrid.SelectedItems[0]).Row["SecondName"].ToString();
                Mobile.Text = ((DataRowView)DataGrid.SelectedItems[0]).Row["Mobile"].ToString();
                Mail.Text = ((DataRowView)DataGrid.SelectedItems[0]).Row["Mail"].ToString();
                id.Content = ((DataRowView)DataGrid.SelectedItems[0]).Row["IdUser"].ToString();

                password.IsEnabled = false;
                login.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Нельзя изменить данные администратора");
            }



        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            admin MWShow = new admin();
            MWShow.Show();
            this.Close();
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


        private void controlCars_Click(object sender, RoutedEventArgs e)
        {
            machine_accounting MWShow = new machine_accounting();
            MWShow.Show();
            this.Close();
        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            history_parking MWShow = new history_parking();
            MWShow.Show();
            this.Close();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            
            DataBase DB1 = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter1 = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT * from place where Owner="+Convert.ToInt32(id.Content)+" ", DB1.GetConnection());

            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);

            DB1.openConnection();

            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.HasRows) // если есть данные
            {
                MessageBox.Show("В данное время изменить данные нельзя, попробуйте позже, когда машина данного пользователя покинет стоянку");
                DB1.closeConnection();
            }
            else
            {
                DataBase DB4 = new DataBase();

                DataTable table4 = new DataTable();

                SqlCommand command4 = new SqlCommand("update users set LoginUser=@LoginUser, FirstName=@FirstName, SecondName=@SecondName, Mobile=@mobile, Mail=@Mail where Users.IdUser=" + Convert.ToInt32(id.Content).ToString() + "", DB4.GetConnection());

                command4.Parameters.Add("@LoginUser", SqlDbType.VarChar).Value = login.Text;
                command4.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName.Text;
                command4.Parameters.Add("@SecondName", SqlDbType.VarChar).Value = SecondName.Text;
                command4.Parameters.Add("@mobile", SqlDbType.VarChar).Value = Mobile.Text;
                command4.Parameters.Add("@Mail", SqlDbType.VarChar).Value = Mail.Text;

                DB4.openConnection();

                if (command4.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные изменены");

                    clean();

                    DataBase DB = new DataBase();

                    DataTable table = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    SqlCommand command = new SqlCommand("SELECT * From users ", DB.GetConnection());

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    DataGrid.ItemsSource = table.DefaultView;


                }
                else
                    MessageBox.Show("Ошибка");

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
    
    
    

