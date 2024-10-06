using BA_PasswordManager.MyDialogWindows;
using BA_PasswordManager.MyPages;
using BA_PasswordManager.MyWindows;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BA_PasswordManager.Classes
{
    [DataContract]
    public class User
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string login { get; set; } = string.Empty;
        [DataMember] public string password { get; set; } = string.Empty;
        [DataMember] public string? email {  get; set; } = string.Empty;

        [DataMember] internal string imageUriIn { get; set; } = string.Empty;
        [DataMember] public string imageUriEx { get; set; } = string.Empty;

        [DataMember] public string firstName { get; set; } = string.Empty;
        [DataMember] public string lastName { get; set; } = string.Empty;
        [DataMember] public bool isEmailVerified { get; set; } = false;
        [DataMember] public bool isOnlineAccount { get; set; } = false;
        [DataMember] public DateTime dateCorrected { get; set; }
        [DataMember] internal bool isThisFirstEntry { get; set; } = true;

        internal User(string login, string password, string imageUriIn = "", string email = "", string firstname = "", string lastname = "", bool isOnlineAccount = false)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.imageUriIn = imageUriIn;
            this.isOnlineAccount = isOnlineAccount;
            if (!isOnlineAccount) isThisFirstEntry = false;

        }

        internal User()
        {

        }
    }

    internal class UserTemplate
    {
        internal User user;
        private Border root { get; set; } = new Border();
        private Grid grid { get; set; } = new Grid();
        private Border image { get; set; } = new Border();
        private Border border { get; set; } = new Border();
        private Viewbox viewbox { get; set; } = new Viewbox();
        private TextBlock AccountName { get; set; } = new TextBlock();

        public UserTemplate(User user)
        {
            this.user = user;
            root.MouseLeftButtonDown += (sender, e) =>
            {
                InputPassWindows inputPass = new InputPassWindows();
                inputPass.ShowDialog();
                if (inputPass.isAccept)
                {
                    if (user.password == inputPass.text)
                    {
                        App.currentUser = user;
                        App.passwordManagerWindow = new PasswordManagerWindow();
                        App.passwordManagerWindow.Show();
                        App.mainWindow.Hide();
                        //Основная программа
                    }
                    else
                    {
                        //Пароль не верный!
                    }
                }                
            };

            root.MouseEnter += (sender, e) =>
            {
                root.Opacity = 0.90;
            };

            root.MouseLeave += Root_MouseLeave;

            root.MouseRightButtonDown += (sender, e) =>
            {
                AcceptWindow acceptWindow = new AcceptWindow(user.login);
                acceptWindow.ShowDialog();
                if (acceptWindow.isAccept)
                {
                    App.users.Remove(user);
                    Crypto.SaveAccountsInFile(App.users, App.key);
                    App.mainWindow.frame.Navigate(new SwitchAccountPage());
                }
            };

            root.Child = grid;
            root.Width = 256;
            root.Height = 350;
            root.Margin = new Thickness(50);
            root.BorderThickness = new Thickness(2);
            root.BorderBrush = new SolidColorBrush(Color.FromRgb(54, 110, 192));
            root.Background = new SolidColorBrush(Color.FromRgb(24, 26, 36));
            root.CornerRadius = new CornerRadius(5);
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(12, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(4, GridUnitType.Star) });
            grid.Children.Add(border);
            border.Margin = new Thickness(50);
            border.BorderThickness = new Thickness(4);
            border.BorderBrush = new SolidColorBrush(Color.FromRgb(37, 39, 47));
            border.Child = image;

            if (user.imageUriIn != null) image.Background = new ImageBrush(new BitmapImage(new Uri(user.imageUriIn)));
            else if (user.imageUriEx != null) { } //TODO: Обработка внешнего изображения 
            else if (user.imageUriEx == null) image.Background = new ImageBrush(new BitmapImage(new Uri("https://www.analitico.pro/wp-content/uploads/2021/08/404-Pagina.jpg", UriKind.Absolute)));

            grid.Children.Add(viewbox);
            viewbox.SetValue(Grid.RowProperty, 1);
            viewbox.Child = AccountName;
            AccountName.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
            AccountName.Margin = new Thickness(5);
            AccountName.Text = user.login;
        }

        private void Root_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            root.Opacity = 1;
        }

        public Border GetTemplate() => root;
        
    }
}
