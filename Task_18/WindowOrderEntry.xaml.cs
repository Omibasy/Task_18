using System;
using System.Windows;
using System.Windows.Input;

namespace Task_18
{
    public partial class WindowOrderEntry : Window
    {
        private int id;
        private string email;
        public goods_order goods;

        public WindowOrderEntry(int id, string email)
        {
            InitializeComponent();

            goods = new goods_order();

            this.id = id;
            this.email = email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckingText())
            {
                goods.id = id;
                goods.Email_User = email;
                goods.item_number = Convert.ToInt32(Item_number.Text);
                goods.product_name = product_name.Text;

                DialogResult = true;
            }
            else
            {
                MessageBox.Show($"Строки не были заполнены");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private bool CheckingText()
        {
            if (Item_number.Text.Trim().Length < 1 ||
                product_name.Text.Trim().Length < 3)
            {
                return false;
            }
            return true;
        }

        private void Item_number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
