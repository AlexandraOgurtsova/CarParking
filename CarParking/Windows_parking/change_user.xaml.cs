using System;
using System.Collections.Generic;
using System.Data;
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

namespace курсовой.Windows_parking
{
    /// <summary>
    /// Логика взаимодействия для change_user.xaml
    /// </summary>
    public partial class change_user : Window
    {
        public change_user(string str1, string str2)
        {
            InitializeComponent();

            change1.Text += str1;

            where.Content += str2;
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
            var regex1 = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,20}(\s*)?$");

            CommandBD cbd = new CommandBD();

            if (where.Content.ToString() == "Mobile")
            {
                if (regex1.IsMatch(change2.Text))
                {
                    cbd.UpdateUserParametr(where.Content.ToString(), change2.Text, where.Content.ToString(), change1.Text);

                    this.Close();
                    MessageBox.Show("Данные изменены, вы сможете увидеть изменения, когда перезапустите приложение");


                }
                else
                {
                    MessageBox.Show("Введите корректный номер мобильного телефона");
                }
            }
            else
            {
                cbd.UpdateUserParametr(where.Content.ToString(), change2.Text, where.Content.ToString(), change1.Text);

                MessageBox.Show("Данные изменены, вы сможете увидеть изменения, когда перезапустите приложение");

                this.Close();
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
