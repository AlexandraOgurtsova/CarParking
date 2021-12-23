using System;
using System.Collections.Generic;
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
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Mime;
using курсовой.Classes;
using System.Net;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для ccheck_out.xaml
    /// </summary>
    public partial class check_out : Window
    {
        public check_out(string number_car, string owner_car, string place_car, string time_begin, string type_car, string period_begin)
        {
            InitializeComponent();

            numberCar.Text += number_car;
            //Owner.Text += owner_car;
            placeCar.Text += place_car;
            timeBegin.Text += time_begin;
            Type.Text += type_car;
            Period.Text += period_begin;

            DataBase DB1 = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter1 = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT SecondName From users where IdUser="+ owner_car+" ", DB1.GetConnection());

            SqlDataReader myreader;
            try
            {
                DB1.openConnection();
                myreader = command1.ExecuteReader();
                while (myreader.Read())
                {
                    Owner.Text = myreader.GetString(0);
                }
                DB1.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            date_time.Text = DateTime.Now.ToString();

            DateTime time_begin = Convert.ToDateTime(timeBegin.Text);
            DateTime time_end = Convert.ToDateTime(date_time.Text);
            TimeSpan time = time_end - time_begin;

            
            if (Type.Text == "сутки")
            {
                int type_days = Convert.ToInt32(Period.Text);
                int sum_days;
                sum_days = type_days * 10;
                summa1.Text = Convert.ToString(sum_days);

                pr.Text = time.Days.ToString();

                if (pr.Text != "0")
                {
                    double summa_1 = sum_days + (Convert.ToInt32(time.Days) * 2);
                    summa2.Text = summa_1.ToString();
                }
                else
                {
                    summa2.Text = summa1.Text;
                }
            }
            else
            {
                double type_hourse = Convert.ToDouble(Period.Text);
                double sum_hourse;
                sum_hourse = type_hourse * 0.5;
                summa1.Text = Convert.ToString(sum_hourse);

                int i = Convert.ToInt32(time.TotalHours);
                pr.Text = i.ToString();


                if (pr.Text != "0")
                {
                    double summa_2 = sum_hourse + (Convert.ToInt32(time.TotalHours) * 0.5);
                    summa2.Text = summa_2.ToString();
                }
                else
                {
                    summa2.Text= summa1.Text;
                }

            }


        }


        private void send_letter_Click(object sender, RoutedEventArgs e)
        {
            

            pdfWork pdf = new pdfWork();
            pdf.letter_formation(Owner.Text, summa2.Text);

            string fn = "check.pdf";//путь к файлу

            DataBase DB = new DataBase();

            DB.InsertIntoHistory("history", "Чек отправлен " + Owner.Text + " ", DateTime.Now);

            MailWork mal = new MailWork();
            if (mal.CheckInternet() == false)
            {
                MessageBox.Show("Проверьте соединение с интернетом");
            }
            else
            {
                mal.Send_letter(Owner.Text);
  
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase DB = new DataBase();
            DB.InsertIntoHistory("history", "Машина " + numberCar.Text + " покинула парковку ", DateTime.Now);

            DB.Delete("place", "Number", placeCar.Text);

            admin MVShow = new admin();
            MVShow.Show();
            this.Close();
            string fn = "check.pdf";
            
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            admin MVShow = new admin();
            MVShow.Show();
            this.Close();
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
