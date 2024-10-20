using System.IO.Compression;
using System.IO;
using System.Windows;

namespace BA_PasswordManager.Classes
{
    internal static class Compression
    {
        
        static string source = "compressor";
        static string zipFile = string.Empty;
        
        public static void compress(User user)
        {
            zipFile = ($"{user.login}_online.data ");
            //App.savePasswordPath = App.currentUser.login + "_userData.baud";
            //App.keyPathInPasswords = App.pmAppData + App.currentUser.login + "_key.baud";
            if (Directory.Exists(source)) { Directory.Delete(source, true); }
            if (File.Exists(zipFile)){ File.Delete(zipFile); }
            Directory.CreateDirectory(source);
            File.Copy(user.login + "_userData.baud", ($"{source}\\{user.login}_userData.baud"), true);
            File.Copy(App.pmAppData + user.login + "_key.baud", ($"{source}\\{user.login}_key.baud"), true);
            ZipFile.CreateFromDirectory(source,zipFile);
            Directory.Delete(source, true);
        }

        public static bool decompress(User user)
        {
            zipFile = ($"{App.pmAppData}{user.login}_online.data ");
            if (File.Exists(zipFile))
            {
                
                ZipFile.ExtractToDirectory(zipFile, AppDomain.CurrentDomain.BaseDirectory);
                File.Move(AppDomain.CurrentDomain.BaseDirectory + "\\" + user.login + "_key.baud", App.pmAppData + user.login + "_key.baud");
                return true;
            }
                else return false;

        }
    }
}
