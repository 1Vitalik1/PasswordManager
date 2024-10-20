using System.Net;
using System.Net.Mail;
using System.IO;
namespace BA_PasswordManager.Classes
{
    public static class EmailService
    {
        //public EmailService()
        //{
            //SendEmail().Wait();
        //}

        public static async Task SendEmailInCode(string to, string code)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 2525;
            string emailFrom = "bapassmanager@mail.ru";
            string emailTo = to;
            string subject = "Код для BAPassMan";
            string body = File.ReadAllText("s");
            body = body.Replace("_Code_", code);
            MailMessage message = new MailMessage(emailFrom, emailTo, subject, body);
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(smtpServer, smtpPort);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("bapassmanager", "KUVmJhFQjMwaMupigVRb");
            client.UseDefaultCredentials = false;

            await client.SendMailAsync(message);
        }
    }
}