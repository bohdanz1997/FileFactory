using System;
using System.Net;
using System.Net.Mail;

namespace FileObmen.Helpers
{
    public class MailHelper
    {
        /// <summary>
        /// Отправка письма на почтовый ящик C# mail send
        /// </summary>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="message">Сообщение</param>
        public static void SendMail(string mailto, string subject, string message)
        {
            if (string.IsNullOrWhiteSpace(mailto))
                return;
            string from = "bogdanz2015@gmail.com";
            string password = "botsmanspaces";
            string smtpServer = "smtp.gmail.com";
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(mailto);
                mail.Subject = subject;
                mail.Body = message;
                var client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }
    }
}