using BA_PasswordManager.Classes;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace BA_PasswordManager.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddLocalAccountPage.xaml
    /// </summary>
    public partial class AddLocalAccountPage : Page
    {
        string? avatarImageUri;
        public AddLocalAccountPage()
        {
            InitializeComponent();
        }

        private void button_save_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.users.Add(new Classes.User(field_login.Text, field_password.Text, avatarImageUri, field_email.Text, field_firstname.Text, field_lastname.Text));
            Crypto.SaveAccountsInFile(App.users, App.key);
            App.mainWindow.frame.Navigate(new SwitchAccountPage());
        }

        private void button_changeImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog imageSelect = new OpenFileDialog();
            imageSelect.Filter = "Файлы рисунков (*.png, *.jpg)|*.png;*.jpg|Все файлы (*.*)|*.*\\";
            if(imageSelect.ShowDialog() == true)
            {
                imageUri.Text = imageSelect.FileName;
                avatarImageUri = imageSelect.FileName;
            }
            //image.Background = new ImageBrush(new BitmapImage(new Uri(user.imageUriIn)));
            imageAvatarPreview.Background = new ImageBrush(new BitmapImage(new Uri(avatarImageUri,UriKind.Absolute)));
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
