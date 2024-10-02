using BA_PasswordManager.Classes;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace BA_PasswordManager.MyPages.SubPages
{
    /// <summary>
    /// Логика взаимодействия для Notes.xaml
    /// </summary>

    public partial class Notes : Page
    {
        public Notes()
        {
            InitializeComponent();
            
            if (File.Exists(App.currentUser.login + "_notes.baud"))NotesField.Text = File.ReadAllText(App.currentUser.login + "_notes.baud");
            status.Text = "Заметки сохранены!";
        }

        private void btn_saveNotes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            status.Text = "Сохранено!";
            if (File.Exists(App.currentUser.login + "_notes.baud")) File.Delete(App.currentUser.login + "_notes.baud");
            File.WriteAllText(App.currentUser.login + "_notes.baud", NotesField.Text);
        }

        private void NotesField_TextChanged(object sender, TextChangedEventArgs e) => status.Text = "Заметки не сохранены!";
        
    }
}
