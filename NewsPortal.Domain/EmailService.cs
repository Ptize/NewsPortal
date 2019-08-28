using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace NewsPortal.Domain
{
    public class EmailService
    {
        //private readonly string _mailLogin;
        //private readonly string _mailPassword;

        //public EmailService(IConfiguration configuration)
        //{
        //    _mailLogin = configuration.GetSection("MailServer:MailLogin").Value;
        //    _mailPassword = configuration.GetSection("MailServer:MailPassword").Value;
        //}

        //TODO: Заменить адрес и smtp сервер на те, которые не будет блочить
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "anewsportal@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect("smtp.yandex.ru", 465, true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate("anewsportal@yandex.ru", "_Aa123456");

                emailClient.Send(emailMessage);

                emailClient.Disconnect(true);
            }
        }
    }
}
