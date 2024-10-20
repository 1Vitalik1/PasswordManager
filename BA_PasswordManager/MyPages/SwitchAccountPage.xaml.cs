using BA_PasswordManager.Classes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            if(!App.isAccountSelectEnabled)
            {
                textBlock_status.Text = "Загрузка данных...";
                foreach(Border button in AllUserList.Children)
                    button.IsEnabled = false;
            }
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
