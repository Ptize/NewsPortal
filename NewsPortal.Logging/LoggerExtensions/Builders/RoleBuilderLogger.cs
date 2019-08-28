using Microsoft.Extensions.Logging;
using NewsPortal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Logging.LoggerExtensions.Builders
{
    public static class RoleBuilderLogger
    {
        private const string BuilderAccepts = "[RoleBuilder] <=== ";
        private const string BuilderReturns = "[RoleBuilder] ===> ";
        private static readonly Action<ILogger, string, Exception> _getMyRoleRequestReceived;
        private static readonly Action<ILogger, Guid, Exception> _getRequestReceived;
        private static readonly Action<ILogger, string, Exception> _addRequestReceived;
        private static readonly Action<ILogger, Guid, IList<string>, Exception> _putRequestReceived;
        private static readonly Action<ILogger, OperationResult, Exception> _putRequestReturns;

        static RoleBuilderLogger()
        {
            _getMyRoleRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(GetMyRoleRequestReceived)),
                BuilderAccepts + "[GetMyRole] with [Login = {Login}].");

            _getRequestReceived = LoggerMessage.Define<Guid>(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(GetRequestReceived)),
                BuilderAccepts + "[Get] with the [UserId = {Id}].");

            _addRequestReceived = LoggerMessage.Define<string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(AddRequestReceived)),
                BuilderAccepts + "[Add] with the [Name = {RoleName}].");

            _putRequestReceived = LoggerMessage.Define<Guid, IList<string>>(
                LogLevel.Debug,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReceived)),
                BuilderAccepts + "[Update] with the [UserId = {Id}] and [Roles = '{Roles}'].");

            _putRequestReturns = LoggerMessage.Define<OperationResult>(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(PutRequestReturns)),
                BuilderReturns + "[Update] returns [OperationResult = {OperationResult}].");

        }
        public static void GetMyRoleRequestReceived(this ILogger logger, string login)
        {
            _getMyRoleRequestReceived(logger, login, null);
        }

        public static void GetRequestReceived(this ILogger logger, Guid id)
        {
            _getRequestReceived(logger, id, null);
        }

        public static void AddRequestReceived(this ILogger logger, string roleName)
        {
            _addRequestReceived(logger, roleName, null);
        }

        public static void PutRequestReceived(this ILogger logger, Guid uid, IList<string> roleNames)
        {
            _putRequestReceived(logger, uid, roleNames, null);
        }

        public static void PutRequestReturns(this ILogger logger, OperationResult operationResult)
        {
            _putRequestReturns(logger, operationResult, null);
        }
    }
}
