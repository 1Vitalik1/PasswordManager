using BA_PasswordManager.Classes;
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
    /// Логика взаимодействия для SwitchAccountPage.xaml
    /// </summary>
    public partial class SwitchAccountPage : Page
    {
        readonly object addUser;
        public SwitchAccountPage()
        {
            InitializeComponent();
            addUser = AllUserList.Children[0];
            showAllUsers();
        }


        private void showAllUsers()
        {
            AllUserList.Children.Clear();
            if (App.users.Count > 0)
            {
                foreach (User user in App.users) AllUserList.Children.Add(new UserTemplate(user).GetTemplate());
            }

            AllUserList.Children.Add((Border)addUser);

        }

        private void button_addUser_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            Grid root = (Grid)border.Child;
            Border borderImage = (Border)root.Children[0];
            Viewbox viewbox = (Viewbox)borderImage.Child;
            TextBlock avatar = (TextBlock)viewbox.Child;
            Viewbox viewbox1 = (Viewbox)root.Children[1];
            TextBlock text = (TextBlock)viewbox1.Child;
            avatar.Foreground = new SolidColorBrush(Colors.Gray);
            text.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void button_addUser_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            Grid root = (Grid)border.Child;
            Border borderImage = (Border)root.Children[0];
            Viewbox viewbox = (Viewbox)borderImage.Child;
            TextBlock avatar = (TextBlock)viewbox.Child;
            Viewbox viewbox1 = (Viewbox)root.Children[1];
            TextBlock text = (TextBlock)viewbox1.Child;
            avatar.Foreground = new SolidColorBrush(Colors.White);
            text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void button_addUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (App.isOfflineOnly) App.mainWindow.frame.Navigate(new AddLocalAccountPage());
            else App.mainWindow.frame.Navigate(new InputAccountTypePage());
        }
    }
}
