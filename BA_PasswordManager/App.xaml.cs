using BA_PasswordManager.Classes;
using BA_PasswordManager.MyPages;
using BA_PasswordManager.MyPages.SubPages;
using BA_PasswordManager.MyWindows;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace BA_PasswordManager
{
    public partial class App : Application
    {
        internal static bool isAccountSelectEnabled = true;
        internal static Ftp ftp = new Ftp();
        internal static User currentUser = new User();
        public static bool isOfflineOnly = false;
        public static readonly string pmAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $"\\.BATeam\\BAPW\\";
        public static string saveAccountsPath = "Data.io";
        private static string keyPath = pmAppData + "key";

        internal static string keyPathInPasswords = string.Empty;
        internal static string savePasswordPath = string.Empty;

        public static string key { get;set; } = string.Empty;
        internal static PasswordManagerWindow passwordManagerWindow = new PasswordManagerWindow();
        internal static PasswordManagerPage passwordManagerPage = new PasswordManagerPage();
        internal static Pass passwordViewer = new Pass();
        internal static Notes notesViewer = new Notes();
        internal static Collection<User> users = new Collection<User>() {};
        internal static MainWindow mainWindow = new MainWindow();
        internal static Collection<Password> userPasswords = new Collection<Password>();

        internal App()
        {
            //EmailService.SendEmailInCode("Perfilov.vitalik2006@gmail.com","123werdrfs").Wait();

            Directory.CreateDirectory(pmAppData);

            if (File.Exists(keyPath)) key = File.ReadAllText(keyPath);
            else 
            {
                key = Crypto.GenerateKey();
                File.WriteAllText(keyPath,key);
            }

            //CollectionEncryption.SaveInFile(users, key);

            if (File.Exists(saveAccountsPath)) 
            {
                Crypto.LoadAccountsInFile(File.ReadAllBytes(saveAccountsPath), key);
            }
            mainWindow.Show();
        }

    }

}
