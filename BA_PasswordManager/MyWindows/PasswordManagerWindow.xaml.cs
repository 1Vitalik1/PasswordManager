using BA_PasswordManager.Classes;
using BA_PasswordManager.MyPages;
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

namespace BA_PasswordManager.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для PasswordManagerWindow.xaml
    /// </summary>
    partial class PasswordManagerWindow : Window
    {
        internal PasswordManagerWindow()
        {
            InitializeComponent();
            App.passwordManagerPage = new PasswordManagerPage();
            frame.Navigate(App.passwordManagerPage);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

        }
    }
}
