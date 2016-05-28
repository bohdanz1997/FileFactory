using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FileObmen.Tools
{
    public class MailSender
    {
        /// <summary>
        /// Отправка письма на почтовый ящик C# mail send
        /// </summary>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="message">Сообщение</param>
        public static void SendMail(string mailto, string message)
        {
            if (string.IsNullOrWhiteSpace(mailto))
                return;
            string from = "bogdanz2015@gmail.com";
            string password = "botsmanspaces";
            string smtpServer = "smtp.gmail.com";
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress(from), 
                    Subject = "Новый файл!", 
                    Body = message
                };
                mail.To.Add(mailto);
                var client = new SmtpClient
                {
                    Host = smtpServer,
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(from.Split('@')[0], password),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}