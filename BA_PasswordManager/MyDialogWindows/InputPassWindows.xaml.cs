
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BA_PasswordManager.MyDialogWindows
{
    /// <summary>
    /// Логика взаимодействия для InputPassWindows.xaml
    /// </summary>
    public partial class InputPassWindows : Window
    {
        public bool isAccept = false;
        public string? text;

        public InputPassWindows()
        {
            InitializeComponent();
        }
        

        private void button_accept_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            text = textBox_pass.Text;
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
