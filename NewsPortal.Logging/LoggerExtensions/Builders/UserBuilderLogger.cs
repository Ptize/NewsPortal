using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPortal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Logging.LoggerExtensions.Builders
{
    public static class UserBuilderLogger
    {
        private const string BuilderAccepts = "[UserBuilder] <=== ";
        private const string BuilderReturns = "[UserBuilder] ===> ";

        private static readonly Action<ILogger, int, int, Exception> _getAllRequestReceived;
        private static readonly Action<ILogger, Exception> _getAllRequestReturnsEmptyList;
        private static readonly Action<ILogger, Guid, Exception> _getRequestReceived;
        private static readonly Action<ILogger, string, Exception> _addRequestReceived;
        private static readonly Action<ILogger, Exception> _putRequestReceived;
        private static readonly Action<ILogger, OperationResult, Exception> _putRequestReturns;
        private static readonly Action<ILogger, Exception> _loginRequestReceived;
        private static readonly Action<ILogger, Exception> _logoutRequestReceived;
        private static readonly Action<ILogger, Exception> _changePasswordRequestReceived;
        private static readonly Action<ILogger, Exception> _changeForgotPasswordRequestReceived;
        private static readonly Action<ILogger, OperationResult, Exception> _changePasswordRequestReturns;
        private static readonly Action<ILogger, OperationResult, Exception> _changeForgotPasswordRequestReturns;

        static UserBuilderLogger()
        {
            _getAllRequestReceived = LoggerMessage.Define<int, int>(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReceived)),
                BuilderAccepts + "[GetAll] with [UsersAmountOnPage = {CountEntity}] and [PageNumber = {Page}].");

            _getAllRequestReturnsEmptyList = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReturnsEmptyList)),
                BuilderReturns + "[GetAll] returns empty list.");

            _getRequestReceived = LoggerMessage.Define<Guid>(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(GetRequestReceived)),
                BuilderAccepts + "[Get] with the [Id = {Id}].");

            _addRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(AddRequestReceived)),
                BuilderAccepts + "[Add] with the [UrlAction = {UrlAction}].");

            _putRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReceived)),
                BuilderAccepts + "[Update] with the [EditUserVM].");

            _putRequestReturns = LoggerMessage.Define<OperationResult>(
                LogLevel.Debug,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReturns)),
                BuilderReturns + "[Update] returns [OperationResult = {OperationResult}].");

            _loginRequestReceived = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.Login, nameof(LoginRequestReceived)),
               BuilderAccepts + "[Login] with the [LoginVM].");

            _logoutRequestReceived = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.Logout, nameof(LogoutRequestReceived)),
               BuilderAccepts + "[Logout] with none parameters.");

            _changePasswordRequestReceived = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.ChangePassword, nameof(ChangePasswordRequestReceived)),
               BuilderAccepts + "[ChangePassword] with the [ChangePasswordVM].");

            _changeForgotPasswordRequestReceived = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.ChangePassword, nameof(ChangeForgotPasswordRequestReceived)),
               BuilderAccepts + "[ChangePassword] with the [ChangeForgotPasswordVM].");

            _changePasswordRequestReturns = LoggerMessage.Define<OperationResult>(
              LogLevel.Debug,
              new EventId(LoggingEvents.ChangePassword, nameof(ChangePasswordRequestReturns)),
              BuilderReturns + "[ChangePassword] returns [OperationResult = {OperationResult}].");

            _changeForgotPasswordRequestReturns = LoggerMessage.Define<OperationResult>(
               LogLevel.Debug,
               new EventId(LoggingEvents.ChangePassword, nameof(ChangeForgotPasswordRequestReturns)),
               BuilderReturns + "[ChangePassword] returns [OperationResult = {OperationResult}].");

        }
        public static void GetAllRequestReceived(this ILogger logger, int count, int page)
        {
            _getAllRequestReceived(logger, count, page, null);
        }

        public static void GetAllRequestReturnsEmptyList(this ILogger logger)
        {
            _getAllRequestReturnsEmptyList(logger, null);
        }

        public static void GetRequestReceived(this ILogger logger, Guid id)
        {
            _getRequestReceived(logger, id, null);
        }

        public static void AddRequestReceived(this ILogger logger, string urlAction)
        {
            _addRequestReceived(logger, urlAction, null);
        }

        public static void PutRequestReceived(this ILogger logger)
        {
            _putRequestReceived(logger, null);
        }

        public static void PutRequestReturns(this ILogger logger, OperationResult operationResult)
        {
            _putRequestReturns(logger, operationResult, null);
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

        public static void ChangePasswordRequestReturns(this ILogger logger, OperationResult operationResult)
        {
            _changePasswordRequestReturns(logger, operationResult, null);
        }

        public static void ChangeForgotPasswordRequestReturns(this ILogger logger, OperationResult operationResult)
        {
            _changeForgotPasswordRequestReturns(logger, operationResult, null);
        }
    }
}
