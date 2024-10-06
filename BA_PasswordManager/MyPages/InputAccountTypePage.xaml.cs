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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BA_PasswordManager.MyPages
{
    /// <summary>
    /// Логика взаимодействия для InputAccountTypePage.xaml
    /// </summary>
    public partial class InputAccountTypePage : Page
    {
        public InputAccountTypePage()
        {
            InitializeComponent();
        }

        private void Button_Local_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.frame.Navigate(new AddLocalAccountPage());
        }

        private void Button_Global_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.frame.Navigate(new AddGlobalAccountPage());
        }

    }
}
