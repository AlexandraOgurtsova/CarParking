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
    /// Логика взаимодействия для add_car.xaml
    /// </summary>
    public partial class add_car : Window
    {
        public add_car(string number_, string owner_, string mobile_)
        {
            InitializeComponent();
            Number.Text += number_;
            Owner.Text += owner_;
            Mobile.Content += mobile_;
        }


        private void add_Click(object sender, RoutedEventArgs e)
        {
            string owner_ = Owner.Text;
            string mobile_ = Mobile.Content.ToString();

            DataBase DB = new DataBase();

            if (DB.Select("users", "SecondName", Owner.Text).Rows.Count > 0)
            {
                if (!(Number.Text == "" || Mark.Text == "" || Type.Text == "" || Colour.Text == "" || Owner.Text == ""))
                {

                    SqlCommand command = new SqlCommand("declare @t int; set @t=(select IdUser from users where users.SecondName='" + owner_ + "' and users.Mobile='" + mobile_ + "'); insert into cars(Number, Mark, Colour, Type, Owner) values (@number, @mark, @colour, @type, @t)", DB.GetConnection());

                    command.Parameters.Add("@number", SqlDbType.VarChar).Value = Number.Text;
                    command.Parameters.Add("@mark", SqlDbType.VarChar).Value = Mark.Text;
                    command.Parameters.Add("@colour", SqlDbType.VarChar).Value = Colour.Text;
                    command.Parameters.Add("@type", SqlDbType.VarChar).Value = Type.Text;
                    command.Parameters.Add("@owner", SqlDbType.VarChar).Value = Owner.Text;

                    DB.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        this.Close();
                        MessageBox.Show("Машина добавлена");

                        DB.InsertIntoHistory("history", "Добавлен автомобиль " + Number.Text, DateTime.Now);


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
                add_user MVShow = new add_user(owner_, mobile_);
                MVShow.Show();
            }
            DB.closeConnection();
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
