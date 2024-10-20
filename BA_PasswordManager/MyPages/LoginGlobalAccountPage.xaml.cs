using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BA_PasswordManager.MyPages
{
    /// <summary>
    /// Логика взаимодействия для LoginGlobalAccountPage.xaml
    /// </summary>
    public partial class LoginGlobalAccountPage : Page
    {
        string? avatarImageUri;

        public LoginGlobalAccountPage()
        {
            InitializeComponent();
        }


        private void button_save_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*
            User current = new Classes.User(field_login.Text, field_password.Text, avatarImageUri, field_email.Text, field_firstname.Text, field_lastname.Text, true);
            App.users.Add(current);

            Crypto.SaveAccountsInFile(App.users, App.key);
            Task.Run(() =>
            {
                using (Database database = new Database())
                {
                    database.Users.AddRange(App.users[App.users.Count - 1]);
                    database.SaveChanges();
                }
            });
            
            Task.Run(() =>
            {
                App.isAccountSelectEnabled = false;
                if (App.currentUser.isThisFirstEntry)
                {
                    App.ftp.loadUserData(current);
                    Compression.decompress(current);
                    App.currentUser.isThisFirstEntry = false;
                }
                App.isAccountSelectEnabled = true;
                App.Current.Dispatcher.Invoke(() => { App.mainWindow.frame.Navigate(new SwitchAccountPage()); });
            });
            */

            App.mainWindow.frame.Navigate(new SwitchAccountPage());
        }

        private void button_changeImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog imageSelect = new OpenFileDialog();
            imageSelect.Filter = "Файлы рисунков (*.png, *.jpg)|*.png;*.jpg|Все файлы (*.*)|*.*\\";
            if (imageSelect.ShowDialog() == true)
            {
                imageUri.Text = imageSelect.FileName;
                avatarImageUri = imageSelect.FileName;
            }
            //image.Background = new ImageBrush(new BitmapImage(new Uri(user.imageUriIn)));
            imageAvatarPreview.Background = new ImageBrush(new BitmapImage(new Uri(avatarImageUri, UriKind.Absolute)));
        }

        private void button_deleteImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            imageUri = null;
            avatarImageUri = null;

        }


        private void button_cancle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.mainWindow.frame.GoBack();
        }
    }
}
