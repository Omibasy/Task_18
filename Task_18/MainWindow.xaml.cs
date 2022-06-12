using System;
using System.Windows;

namespace Task_18
{
    public partial class MainWindow : Window
    {
      
        //login admin
        //password admin


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            var baseData = Connect.Verification(Login.Text, Password.Text);

            if (baseData != null)
            {
                WindowCustomerTable window2 = new WindowCustomerTable();

                window2.LoadDb(baseData);

                this.Close();

                window2.Show();
            }
            else
            {
                MessageBox.Show("Не верный логи или пароль");
            }
        }
    }
}

