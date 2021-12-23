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
    /// Логика взаимодействия для arking_places.xaml
    /// </summary>
    public partial class parking_places : Window
    {
        public parking_places(string str)
        {
            InitializeComponent();
            populateButtons();

            control.Content += str;

        }


            public void take_place(object sender)
        {
            Button clicked = (Button)sender;

            string number_ = clicked.Content.ToString();

            DataBase DB = new DataBase();

            DataTable table1 = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command1 = new SqlCommand("SELECT Number From place WHERE Status_ = 'занято'", DB.GetConnection());

            SqlDataReader myreader;
            try
            {
                DB.openConnection();
                myreader = command1.ExecuteReader();
                while (myreader.Read())
                {
                    string snumber = myreader.GetString(0);

                    if (clicked.Content.ToString() == snumber)
                    {
                        clicked.IsEnabled = false;
                        clicked.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF0000"));
                    }

                }
                DB.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("errorrrrrrrrr");
            }
        }

        public void populateButtons()
        {
            int xPos=0;
            int yPos=0;

            Random ranNum = new Random();

            for (int i = 1; i < 11; i++)
            {
                Button foo = new Button();


                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));


                xPos = 50;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 11; i < 21; i++)
            {
                Button foo = new Button();

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));


                xPos = 150;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);


                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);


            }
            yPos = 0;
            for (int i = 21; i < 31; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 250;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 31; i < 41; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 350;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 41; i < 51; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 450;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 51; i < 61; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 550;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 61; i < 71; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 650;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 71; i < 81; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 750;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 81; i < 91; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 850;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }
            yPos = 0;
            for (int i = 91; i < 101; i++)
            {
                Button foo = new Button();
                //Style buttonStyle = Window.Resources["CurvedButton"] as Style;

                int sizeValue = ranNum.Next(50);

                foo.Width = 50;
                foo.Height = 40;
                foo.Name = "button" + i;
                foo.Content = i;
                foo.Background = new SolidColorBrush(Color.FromRgb(192, 192, 192));

                //xPos = ranNum.Next(300);
                //yPos = ranNum.Next(200);

                xPos = 950;
                yPos += 40;

                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);

                //foo.Style = buttonStyle;

                foo.Click += new RoutedEventHandler(buttonClick);
                MainGrid.Children.Add(foo);

                take_place(foo);
            }


        }

        private void buttonClick(object sender, EventArgs e)
        {

            if (control.Content.ToString() == "")
            {
                Button clicked = (Button)sender;
                string number_ = clicked.Content.ToString();
                check_in MWShow = new check_in(number_);
                MWShow.Show();
                this.Close();
            }
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if (control.Content.ToString() == "")
            {
                admin MVSHow = new admin();
                MVSHow.Show();
                this.Close();
            }
            else
            {
                this.Close();
            }

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
