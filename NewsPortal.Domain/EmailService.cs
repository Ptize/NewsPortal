using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using static NewsPortal.Logging.LoggerExtensions.Services.EmailServiceLogger;
using System;
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
        private readonly ILogger _logger = new Logger<EmailService>(new LoggerFactory());

        private const string EmailFrom = "anewsportal@yandex.ru";
        private const string NameFrom = "Администрация сайта";
        private const string NameTo = "";
        private const string Host = "smtp.yandex.ru";
        private const int Port = 465;
        private const bool DoUseSSL = true;
        private const string AuthenticationMechanismToRemove = "XOAUTH2";
        private const string MyEmail = "anewsportal@yandex.ru";
        private const string Password = "_Aa123456";

        //TODO: Заменить адрес и smtp сервер на те, которые не будет блочить
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(NameFrom, EmailFrom));
            emailMessage.To.Add(new MailboxAddress(NameTo, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            _logger.MessageCreated(EmailFrom, email, subject, message);
            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                try
                {
                    //The last parameter here is to use SSL (Which you should!)
                    await emailClient.ConnectAsync(Host, Port, DoUseSSL);
                    _logger.ConnectedToSmtp(Host, Port, DoUseSSL);

                    //Remove any OAuth functionality as we won't be using it. 
                    emailClient.AuthenticationMechanisms.Remove(AuthenticationMechanismToRemove);
                    _logger.AuthenticationMechanismRemoved(AuthenticationMechanismToRemove);

                    await emailClient.AuthenticateAsync(MyEmail, Password);
                    _logger.Authenticated(MyEmail, Password);

                    await emailClient.SendAsync(emailMessage);
                    _logger.MailSent();

                    await emailClient.DisconnectAsync(true);
                    _logger.Disconnected();
                }
                catch(Exception ex)
                {
                    _logger.ErrorOccured(ex);
                }
            }
        }
    }
}
