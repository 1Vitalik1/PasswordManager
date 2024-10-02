using BA_PasswordManager.MyPages.SubPages;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BA_PasswordManager.MyPages
{
    /// <summary>
    /// Логика взаимодействия для PasswordManagerPage.xaml
    /// </summary>
    public partial class PasswordManagerPage : Page
    {
        Collection<Border> menu = new Collection<Border>();
        Brush brush;
        public PasswordManagerPage()
        {
            InitializeComponent();

            foreach (Border button in menuStack.Children)
                menu.Add(button);

            App.savePasswordPath = App.currentUser.login + "_userData.baud";
            App.keyPathInPasswords = App.pmAppData + App.currentUser.login + "_key.baud";


            LoadData();
            App.passwordViewer = new Pass();
            App.notesViewer = new Notes();
            frame.Navigate(App.passwordViewer);

        }

        private void LoadData()
        {
            if (File.Exists(App.savePasswordPath)) Crypto.LoadPasswrodsInFile<string>(File.ReadAllBytes(App.savePasswordPath), File.ReadAllText(App.keyPathInPasswords), App.currentUser);
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            brush = border.Background;
            border.Background = new SolidColorBrush(Color.FromRgb(22, 37, 82));

        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            border.Background = brush;
        }

        private void button_password_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.passwordManagerPage.frame.NavigationService.Navigate(App.passwordViewer);
            anim(sender);
        }

        private void anim(object sender)
        {
            foreach (Border border in menu)
            {
                Viewbox viewbox = (Viewbox)border.Child;
                TextBlock textBlock = (TextBlock)viewbox.Child;
                textBlock.Foreground = new SolidColorBrush(Colors.White);
            }
            Border border1 = (Border)sender;
            Viewbox viewbox1 = (Viewbox)border1.Child;
            TextBlock textBlock1 = (TextBlock)viewbox1.Child;
            textBlock1.Foreground = new SolidColorBrush(Color.FromRgb(54, 110, 192));
        }

        private void button_notes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.passwordManagerPage.frame.NavigationService.Navigate(App.notesViewer);
            anim(sender);
        }

        private void button_cards_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            anim(sender);
        }

        private void button_options_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            anim(sender);
        }

        private void button_exit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
