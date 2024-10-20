using BA_PasswordManager.Classes;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using MimeKit;

namespace BA_PasswordManager.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddLocalAccountPage.xaml
    /// </summary>
    public partial class AddGlobalAccountPage : Page
    {
        string key;
        string? avatarImageUri;
        public AddGlobalAccountPage()
        {
            InitializeComponent();
        }

        private void button_save_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(field_login.Text == string.Empty) { MessageBox.Show("Введите логин!"); return; }
            if (field_password.Text == string.Empty) { MessageBox.Show("Введите пароль!"); return; }
            if (field_email.Text == string.Empty) { MessageBox.Show("Введите почту!"); return; }
            if(field_key.Text == string.Empty) { MessageBox.Show("Вы не ввели ключ!"); return; }
            if (key == field_key.Text && key != "" && field_key.Text != "")
            {
                User current = new Classes.User(field_login.Text, field_password.Text, avatarImageUri, field_email.Text, field_firstname.Text, field_lastname.Text, true);
                current.isEmailVerified = true;

                bool isDuplicateUser = false;

                using (Database db = new Database())
                {
                    isDuplicateUser = db.Users.Any(u => u.login == current.login);
                }

                if (!isDuplicateUser)
                {
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

                    App.mainWindow.frame.Navigate(new SwitchAccountPage());
                }
                else MessageBox.Show("Пользователь с таким логином уже зарегистрирован.");
                
            }
            else MessageBox.Show("Введён не правильный код!");
            

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

        private void sendKeyToMail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            field_email.TextChanged += Field_email_TextChanged;
            key = PasswordGenerator.generateKey();
            //EmailService.SendEmailInCode("Perfilov.vitalik2006@gmail.com","123werdrfs").Wait();
            EmailService.SendEmailInCode($"{field_email}",$"{key}");
        }

        private void Field_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            key = string.Empty;
            field_key.Text = string.Empty;
        }
    }
}
