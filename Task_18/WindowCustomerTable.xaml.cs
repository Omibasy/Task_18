using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace Task_18
{
    
    public partial class WindowCustomerTable : Window
    {
        private bool isEditEnding;
        MSSQLlocalDBEntities2 baseData;

        public WindowCustomerTable()
        {
            InitializeComponent();
        }

        public void LoadDb(MSSQLlocalDBEntities2 baseData)
        {
            this.baseData = baseData;

            this.baseData.buyers.Load();

            TableSQL.DataContext = this.baseData.buyers.Local.ToBindingList<buyers>();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowNewUser add = new WindowNewUser(TableSQL.Items.Count + 1);

            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                baseData.buyers.Add(add.dataRow);

                baseData.SaveChanges();
            }
        }


        private void TableSQL_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

            buyers buyers = (buyers)TableSQL.SelectedItem;

            var client = "Вы хотите удалить данного клиента: " + ((buyers)TableSQL.SelectedItem).Surname + " " +
                                                                 ((buyers)TableSQL.SelectedItem).Name + " " +
                                                                 ((buyers)TableSQL.SelectedItem).Patomic;

            var result = MessageBox.Show(client, "Удаление", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                baseData.buyers.Remove(buyers);

                baseData.SaveChanges();
            }
        }

        private bool CheckingCharacters(int index)
        {
            var cellInfo = TableSQL.SelectedCells[index];

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
            string nameUser = $"{((buyers)TableSQL.SelectedItem).Surname}" +
                              $"{((buyers)TableSQL.SelectedItem).Name}" +
                              $" {((buyers)TableSQL.SelectedItem).Patomic}";

            WindowTableGoods window1 = new WindowTableGoods(((buyers)TableSQL.SelectedItem).Email,
                                                            nameUser, baseData);

            this.Hide();

            window1.ShowDialog();

            this.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            baseData.SaveChanges();

            MainWindow mainWindow = new MainWindow();

            this.Close();

            mainWindow.Show();
        }

        private void TableSQL_CurrentCellChanged(object sender, EventArgs e)
        {
            baseData.SaveChanges();
        }
    }
}

