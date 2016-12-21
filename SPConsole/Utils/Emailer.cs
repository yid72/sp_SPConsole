using System.Net.Mail;

namespace SPConsole.Utils
{
    public class Emailer
    {
        SmtpClient emailClient;

        public Emailer()
        {
            this.emailClient = new SmtpClient("spoedogeop.mail.protection.outlook.com");
//            this.emailClient.ClientCertificates.Add(certificate);
//            this.emailClient.EnableSsl = true;
            this.emailClient.UseDefaultCredentials = true;
        }

        public void SendEmail(string from, string to, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body)
            {
                IsBodyHtml = true
            };

            this.emailClient.SendMailAsync(message);
        }
    }
}
