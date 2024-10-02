
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BA_PasswordManager.MyDialogWindows
{
    /// <summary>
    /// Логика взаимодействия для AcceptWindow.xaml
    /// </summary>
    public partial class AcceptWindow : Window
    {
        public bool isAccept = false;
        public AcceptWindow(string AccountName)
        {
            InitializeComponent();
            textBlock_accountName.Text = AccountName;

        }

        private void button_accept_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isAccept = true;
            this.Close();
        }

        private void button_cancle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isAccept = false;
            this.Close();
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            border.Opacity = 0.90;
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {

            Border border = (Border)sender;
            border.Opacity = 1;
        }
    }
}
