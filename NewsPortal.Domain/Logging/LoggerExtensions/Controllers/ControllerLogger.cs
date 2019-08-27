using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Domain.Logging.LoggerExtensions.Controllers
{
    public static class ControllerLogger
    {
        private static readonly Action<ILogger, string, Exception> _getAllRequestReceived;
        private static readonly Action<ILogger, string, Exception> _getRequestReceived;
        private static readonly Action<ILogger, string, Exception> _addRequestReceived;
        private static readonly Action<ILogger, string, Exception> _putRequestReceived;
        private static readonly Action<ILogger, string, Exception> _deleteRequestReceived;
        private static readonly Action<ILogger, Exception> _loginRequestReceived;
        private static readonly Action<ILogger, Exception> _logoutRequestReceived;
        private static readonly Action<ILogger, Exception> _changePasswordRequestReceived;
        private static readonly Action<ILogger, Exception> _changeForgotPasswordRequestReceived;
        private static readonly Action<ILogger, Exception> _indexPageRequestReceived;

        static ControllerLogger()
        {
            _getAllRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReceived)),
                "GET request for the list of {Entity}s");

            _getRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(LoggingEvents.GetItem, nameof(GetRequestReceived)),
                "GET request for the {Entity} with the id");

            _addRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(LoggingEvents.InsertItem, nameof(AddRequestReceived)),
                "POST request for adding the {Entity}");

            _putRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReceived)),
                "PUT request for modifying the existing {Entity}");

            _deleteRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Information,
                new EventId(LoggingEvents.DeleteItem, nameof(DeleteRequestReceived)),
                "DELETE request for deleting the existing {Entity}");

            _loginRequestReceived = LoggerMessage.Define(
               LogLevel.Information,
               new EventId(LoggingEvents.Login, nameof(LoginRequestReceived)),
               "POST request for logging in");

            _logoutRequestReceived = LoggerMessage.Define(
               LogLevel.Information,
               new EventId(LoggingEvents.Logout, nameof(LogoutRequestReceived)),
               "POST request for logging out");

            _changePasswordRequestReceived = LoggerMessage.Define(
               LogLevel.Information,
               new EventId(LoggingEvents.ChangePassword, nameof(ChangePasswordRequestReceived)),
               "POST request for changing the password");

            _changeForgotPasswordRequestReceived = LoggerMessage.Define(
               LogLevel.Information,
               new EventId(LoggingEvents.ChangePassword, nameof(ChangeForgotPasswordRequestReceived)),
               "POST request for changing the forgotten password");

            _indexPageRequestReceived = LoggerMessage.Define(
                LogLevel.Information,
                new EventId(LoggingEvents.SendPage, nameof(IndexPageRequestReceived)),
                "GET request for Index page");
        }

        public static void GetAllRequestReceived(this ILogger logger, string entity)
        {
            _getAllRequestReceived(logger, entity, null);
        }

        public static void GetRequestReceived(this ILogger logger, string entity)
        {
            _getRequestReceived(logger, entity, null);
        }

        public static void AddRequestReceived(this ILogger logger, string entity)
        {
            _addRequestReceived(logger, entity, null);
        }

        public static void PutRequestReceived(this ILogger logger, string entity)
        {
            _putRequestReceived(logger, entity, null);
        }

        public static void DeleteRequestReceived(this ILogger logger, string entity)
        {
            _deleteRequestReceived(logger, entity, null);
        }

        public static void LoginRequestReceived(this ILogger logger)
        {
            _loginRequestReceived(logger, null);
        }

        public static void LogoutRequestReceived(this ILogger logger)
        {
            _logoutRequestReceived(logger, null);
        }

        public static void ChangePasswordRequestReceived(this ILogger logger)
        {
            _changePasswordRequestReceived(logger, null);
        }

        public static void ChangeForgotPasswordRequestReceived(this ILogger logger)
        {
            _changeForgotPasswordRequestReceived(logger, null);
        }

        public static void IndexPageRequestReceived(this ILogger logger)
        {
            _indexPageRequestReceived(logger, null);
        }
    }
}
