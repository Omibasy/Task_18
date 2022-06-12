using System.Windows;

namespace Task_18
{
    public partial class WindowNewUser : Window
    {
        public buyers dataRow;
        private bool isItAnEmail;
        private int id;

        public WindowNewUser(int id)
        {
            InitializeComponent();

            isItAnEmail = false;
            dataRow = new buyers();
            this.id = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CorrectnessEmael();

            if (CheckingText())
            {
                dataRow.id = id;
                dataRow.Name = NameTxt.Text;
                dataRow.Surname = SurnameTxt.Text;
                dataRow.Patomic = PatomicTxt.Text;

                EmptyNumber();

                dataRow.Email = EmailTxt.Text;

                if (isItAnEmail)
                {
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Не верно введен email");
                }
            }
            else
            {
                string itAnEmail;

                if (isItAnEmail)
                {
                    itAnEmail = "";
                }
                else
                {
                    itAnEmail = "А так же не верно введен email";
                }
                MessageBox.Show($"Строки не были {itAnEmail}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private bool CheckingText()
        {
            ;
            if (SurnameTxt.Text.Trim().Length < 3 ||
                NameTxt.Text.Trim().Length < 3 ||
                SurnameTxt.Text.Trim().Length < 3 ||
                EmailTxt.Text.Trim().Length < 3)
            {
                return false;
            }
            return true;
        }

        private void CorrectnessEmael()
        {
            foreach (char item in EmailTxt.Text)
            {
                if (item == '@')
                {
                    isItAnEmail = true;
                }
            }
        }

        private void EmptyNumber()
        {
            if (PhoneNumberTxt.Text.Trim() == "")
            {
                dataRow.PhoneNumber = null;
            }
            else
            {
                dataRow.PhoneNumber = PhoneNumberTxt.Text;
            }
        }
    }
}


