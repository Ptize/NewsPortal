using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Logging.LoggerExtensions.Services
{
    public static class EmailServiceLogger
    {
        private static readonly Action<ILogger, string, string, string, string, Exception> _messageCreated;
        private static readonly Action<ILogger, string, int, bool, Exception> _connectedToSmtp;
        private static readonly Action<ILogger, string, Exception> _authenticationMechanismRemoved;
        private static readonly Action<ILogger, string, string, Exception> _authenticated;
        private static readonly Action<ILogger, Exception> _mailSent;
        private static readonly Action<ILogger, Exception> _disconnected;
        private static readonly Action<ILogger, Exception> _errorOccured;

        static EmailServiceLogger()
        {
            _messageCreated = LoggerMessage.Define<string, string, string, string>(
                LogLevel.Information,
                new EventId(LoggingEvents.GenerateItems, nameof(MessageCreated)),
                "Message was created from [email = <{EmailFrom}>] to [email = <{EmailTo}> with [subject = <{Subject}>] and [message = '{Message}']");

            _connectedToSmtp = LoggerMessage.Define<string, int, bool>(
                LogLevel.Debug,
                new EventId(LoggingEvents.Connect, nameof(ConnectedToSmtp)),
                "Connected to SMTP with [Host = {Host}], [Port = {Port}], [Using SSL: {DoUseSSL}]");

            _authenticationMechanismRemoved = LoggerMessage.Define<string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.Authenticate, nameof(AuthenticationMechanismRemoved)),
                "Authentication mechanism [{Mechanism}] was removed.");

            _authenticated = LoggerMessage.Define<string, string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.Authenticate, nameof(Authenticated)),
                "Authenticated with [Username = {Username}] and [Password = {Password}]");

            _mailSent = LoggerMessage.Define(
                LogLevel.Information,
                new EventId(LoggingEvents.Send, nameof(MailSent)),
                "Mail was sent.");

            _disconnected = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.Disconnect, nameof(Disconnected)),
                "Disconnected from SMTP Client.");

            _errorOccured = LoggerMessage.Define(
                LogLevel.Error,
                new EventId(LoggingEvents.SmtpClientError, nameof(ErrorOccured)),
                "Working with SMTP Client failed.");
        }

        public static void MessageCreated(this ILogger logger, string emailFrom, string emailTo, string subject, string message)
        {
            _messageCreated(logger, emailFrom, emailTo, subject, message, null);
        }

        public static void ConnectedToSmtp(this ILogger logger, string Host, int Port, bool DoUseSSL)
        {
            _connectedToSmtp(logger, Host, Port, DoUseSSL, null);
        }

        public static void AuthenticationMechanismRemoved(this ILogger logger, string mechanism)
        {
            _authenticationMechanismRemoved(logger, mechanism, null);
        }

        public static void Authenticated(this ILogger logger, string username, string password)
        {
            _authenticated(logger, username, password, null);
        }

        public static void MailSent(this ILogger logger)
        {
            _mailSent(logger, null);
        }

        public static void Disconnected(this ILogger logger)
        {
            _disconnected(logger, null);
        }

        public static void ErrorOccured(this ILogger logger, Exception ex)
        {
            _errorOccured(logger, ex);
        }

    }
}
