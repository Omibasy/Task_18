using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace Task_18
{
    
    public partial class WindowTableGoods : Window
    {

        private string email;
        private bool isEditEnding;
        private MSSQLlocalDBEntities2 baseData;

        public WindowTableGoods(string email, string userName, MSSQLlocalDBEntities2 baseData)
        {
            InitializeComponent();

            NameUser.Text = $"Заказы пользователя {userName}";

            this.email = email;
            this.baseData = baseData;

            this.baseData.goods_order.Load();

            Load();
        }


        private void Load()
        {
            TableGoods.DataContext = baseData.goods_order.Local.Where<goods_order>(e => e.Email_User == email).ToList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            goods_order rowView = (goods_order)TableGoods.SelectedItem;

            var client = $"Вы хотите удалить заказ на товар: {rowView.product_name}";

            var result = MessageBox.Show(client, "Удаление", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                baseData.goods_order.Remove(rowView);

                baseData.SaveChanges();

                Load();
            }
        }

        private void TableGoods_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (isEditEnding)
            {
                return;
            }
            try
            {
                isEditEnding = true;

                if (CheckingCharacters(e.Column.DisplayIndex))
                {
                    (sender as DataGrid).CancelEdit();

                    MessageBox.Show("Данные не могут быть пустыми");
                }
      
            }
            finally
            {
                isEditEnding = false;
            }
        }

        private bool CheckingCharacters(int index)
        {
            var cellInfo = TableGoods.SelectedCells[index];

            var content = cellInfo.Column.GetCellContent(cellInfo.Item);

            string cellData = content.ToString();

            if (cellData.Length < 34)
            {
                return true;
            }

            return false;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            int id = baseData.goods_order.Local.Last<goods_order>().id;

            WindowOrderEntry add = new WindowOrderEntry(++id, email);

            add.ShowDialog();

            if (add.DialogResult.Value)
            {

                baseData.goods_order.Add(add.goods);

                baseData.SaveChanges();

                Load();
            }          
        }

        private void TableGoods_CurrentCellChanged(object sender, EventArgs e)
        {
            baseData.SaveChanges();

            Load();
        }
    }
}


