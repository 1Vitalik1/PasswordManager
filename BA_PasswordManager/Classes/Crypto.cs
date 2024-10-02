using BA_PasswordManager;
using BA_PasswordManager.Classes;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;

public static class Crypto
{
    public static void SaveAccountsInFile<T>(ICollection<T> collection, string key)
    {
        string path = App.saveAccountsPath;
        if (File.Exists(path)) File.Delete(path);
        File.WriteAllBytes(path, SerializeAndEncrypt(collection, key));
    }

    public static void LoadAccountsInFile(byte[] encryptedData, string key)
    {
        string path = App.saveAccountsPath;
        var usersList = DecryptAndDeserialize<User>(encryptedData, key);
        App.users = new Collection<User>(usersList);
    }

    public static void SavePasswordsInFile<T>(ICollection<T> collection, string key, User user)
    {
        string path = App.savePasswordPath;
        if(File.Exists(path)) File.Delete(path);
        File.WriteAllBytes(path, SerializeAndEncrypt(collection, key));
    }

    public static void LoadPasswrodsInFile<T>(byte[] encryptedData, string key,User user)
    {
        string path = App.pmAppData + user.login + "_userData.baud";
        var passwordList = DecryptAndDeserialize<Password>(encryptedData, key);
        App.userPasswords = new Collection<Password>(passwordList);
    }

    public static string GenerateKey()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] keyBytes = new byte[32]; 
            rng.GetBytes(keyBytes);

            return Convert.ToBase64String(keyBytes);
        }
    }

    public static byte[] SerializeAndEncrypt<T>(ICollection<T> collection, string key)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<T>));
            serializer.WriteObject(memoryStream, new List<T>(collection));

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key); 
                aes.GenerateIV();

                using (MemoryStream encryptedStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        memoryStream.Position = 0;
                        memoryStream.CopyTo(cryptoStream);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] ivWithEncryptedData = new byte[aes.IV.Length + encryptedStream.ToArray().Length];
                    Buffer.BlockCopy(aes.IV, 0, ivWithEncryptedData, 0, aes.IV.Length);
                    Buffer.BlockCopy(encryptedStream.ToArray(), 0, ivWithEncryptedData, aes.IV.Length, encryptedStream.ToArray().Length);

                    return ivWithEncryptedData;
                }
            }
        }
    }

    public static List<T> DecryptAndDeserialize<T>(byte[] encryptedData, string key)
    {
        using (MemoryStream memoryStream = new MemoryStream(encryptedData))
        {
            byte[] iv = new byte[16]; 
            memoryStream.Read(iv, 0, iv.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.IV = iv;

                using (MemoryStream decryptedStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(decryptedStream);
                    }

                    decryptedStream.Position = 0;

                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<T>));
                    return (List<T>)serializer.ReadObject(decryptedStream);
                }
            }
        }
    }
}
