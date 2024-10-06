using FluentFTP;

namespace BA_PasswordManager.Classes
{
    internal class Ftp
    {
        private readonly FtpClient _client;

        public Ftp()
        {
            _client = new FtpClient("155.254.246.47", "BloodyAlpha", "2006Vitalik2006");
        }

        internal bool saveUserData(User user)
        {
            string fileFromSend = ($"{user.login}_online.data");
            _client.AutoConnect();
            if (_client.FileExists(fileFromSend))
                _client.DeleteFile(fileFromSend);
            _client.UploadFiles(new string[] { fileFromSend,}, "/www.BloodyAlpha.somee.com/UserData");
            string[] strings = _client.GetNameListing();
            _client.Disconnect();
            return true;
        }

        internal bool loadUserData(User user)
        {
            string fileFromGet = ($"{user.login}_online.data");
            _client.AutoConnect();
            if (_client.FileExists($"/www.BloodyAlpha.somee.com/UserData/{fileFromGet}"))
                _client.DownloadFiles(($"{App.pmAppData}"), new string[] { ($"/www.BloodyAlpha.somee.com/UserData/{fileFromGet}") } );
            return true;    
        }

        
    }
}

