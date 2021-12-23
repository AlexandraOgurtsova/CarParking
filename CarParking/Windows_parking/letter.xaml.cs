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

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для letter.xaml
    /// </summary>
    public partial class letter : Window
    {
        public letter(string login)
        {
            InitializeComponent();

            CommandBD cbd = new CommandBD();

            DataTable dt = new DataTable();

            dt = cbd.Select("users", "SecondName", login);

            secondName.Content = dt.Rows[0]["SecondName"].ToString();

        }

        private void Mail_LostFocus(object sender, RoutedEventArgs e)
        {

            CommandBD cbd = new CommandBD();

            DataTable dt = new DataTable();

            string mail = "";

            dt = cbd.Select("users", "SecondName", secondName.Content.ToString());
            mail = dt.Rows[0]["Mail"].ToString();

            if (mail != "")
            {
                MessageBox.Show("Этот адрес уже есть в базе, введите другой");
            }

           
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DB.openConnection();

            SqlCommand command1 = new SqlCommand("update users set Mail='" + MailUser.Text + "' where SecondName='" + secondName.Content.ToString() + "'", DB.GetConnection());

            DB.openConnection();

            if (command1.ExecuteNonQuery() == 1)
            {
                DB.InsertIntoHistory("history", "Чек отправлен на " + MailUser.Text + " ", DateTime.Now);

            }
            else
            {
                MessageBox.Show("error");
            }

            MailWork mal = new MailWork();
            if (mal.CheckInternet() == false)
            {
                MessageBox.Show("Проверьте соединение с интернетом");
            }
            else
            {
                mal.Send_letter(secondName.Content.ToString());

                MessageBox.Show("Чек отправлен");
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

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
