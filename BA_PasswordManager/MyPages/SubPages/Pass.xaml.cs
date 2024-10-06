using BA_PasswordManager.Classes;
using BA_PasswordManager.MyDialogWindows;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace BA_PasswordManager.MyPages.SubPages
{
    /// <summary>
    /// Логика взаимодействия для Pass.xaml
    /// </summary>
    public partial class Pass : Page
    {
        int modeIndex;
        bool  isMode = false;
        public Pass()
        {
            InitializeComponent();
            moreInfo.Width = new GridLength(0, GridUnitType.Star);
            viewAllPassword();
        }

        protected void viewAllPassword()
        {
            passwordViewer.Children.Clear();
            if(App.userPasswords != null)
            {
                foreach(Password password in App.userPasswords)
                {
                    Border pass = new PasswordTemplate(password).getTemplate();
                    passwordViewer.Children.Add(pass);
                    pass.MouseRightButtonDown += (o, e) =>
                    {
                        int id = passwordViewer.Children.IndexOf((Border)o);
                        AcceptWindow acceptWindow = new AcceptWindow(App.userPasswords[id].name);
                        acceptWindow.ShowDialog();
                        if (acceptWindow.isAccept)
                        {
                            App.userPasswords.RemoveAt(id);
                            viewAllPassword();
                            saveAndCrypt();
                        }
                    };
                }

            }
        }

        private void button_addPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMode = false;
            ClearAll();
            moreInfo.Width = new GridLength(40, GridUnitType.Star);
        }

        internal void modePass(Password password)
        {
            isMode = true;
            modeIndex = App.userPasswords.IndexOf(password);
            moreInfo.Width = new GridLength(40, GridUnitType.Star);
            field_email.Text = password.email;
            field_login.Text = password.login;
            field_pass.Text = password.password;
            field_passName.Text = password.name;
            field_phone.Text = password.phone;
            showAllNotesInPassword(password);
        }

        private void showAllNotesInPassword(Password password)
        {
            fieldList_notes.Items.Clear();
            if (password.note != null)
            {
                foreach (string note in password.note)
                    fieldList_notes.Items.Add(note);
            }
        }

        internal void modePassSave()
        {
            Collection<string> allNotes = new Collection<string>();

            if(fieldList_notes.Items != null)
                foreach(string note in fieldList_notes.Items) allNotes.Add(note);
            
            
            if (App.userPasswords == null) App.userPasswords = new Collection<Password>();
            if (isMode)
            {
                App.userPasswords[modeIndex] = new Password(field_passName.Text, field_login.Text, field_email.Text, field_pass.Text, null, field_phone.Text,allNotes);
                viewAllPassword();
            }
            else
            {
                App.userPasswords.Add(new Password(field_passName.Text, field_login.Text, field_email.Text, field_pass.Text, null, field_phone.Text,allNotes));
                viewAllPassword();
            }
            App.currentUser.dateCorrected = DateTime.Now;
            saveAndCrypt();

            if(App.currentUser.isOnlineAccount)
            {
                Compression.compress(App.currentUser);
                App.ftp.saveUserData(App.currentUser);
            }
        }

        private void saveAndCrypt()
        {
            if (File.Exists(App.savePasswordPath)) File.Delete(App.savePasswordPath);
            if (File.Exists(App.keyPathInPasswords)) File.Delete(App.keyPathInPasswords);
            string key = Crypto.GenerateKey();
            File.WriteAllText(App.keyPathInPasswords, key);
            Crypto.SavePasswordsInFile(App.userPasswords, key, App.currentUser);
        }

        private void Button_AcceptAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(field_passName.Text != string.Empty)
            {
                modePassSave();
                ClearAll();
            }
            else
            {
                field_passName.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void ClearAll()
        {
            moreInfo.Width = new GridLength(0, GridUnitType.Star);
            field_email.Text = string.Empty;
            field_login.Text = string.Empty;
            field_pass.Text = string.Empty;
            field_passName.Text = string.Empty;
            field_phone.Text = string.Empty;
            fieldList_notes.Items.Clear();
            field_note.Text = string.Empty;
            isMode = false;
            modeIndex = -1;
        }

        private void CancleAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearAll();
            isMode = false;
        }

        private void addNotes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(field_note.Text != string.Empty)
            {
                fieldList_notes.Items.Add(field_note.Text);
                field_note.Text = string.Empty;
            }
            
        }

        private void deleteNotes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(fieldList_notes.SelectedIndex >= 0) 
                fieldList_notes.Items.RemoveAt(fieldList_notes.SelectedIndex);
        }

        private void button_randomPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) =>
            field_pass.Text = PasswordGenerator.generatePassword(15);

        private void field_passName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Background = new SolidColorBrush(Colors.WhiteSmoke);
        }
    }
}
