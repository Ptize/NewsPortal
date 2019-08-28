using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Logging.LoggerExtensions.Data
{
    public static class DataSeedLogger
    {
        private static readonly Action<ILogger, Exception> _addingNews;
        private static readonly Action<ILogger, int, Exception> _newsAdded;
        private static readonly Action<ILogger, IList<string>, Exception> _checkingIfRolesExist;
        private static Func<ILogger, int, IDisposable> _allRolesExistScope;
        private static readonly Action<ILogger, string, Exception> _roleExists;
        private static readonly Action<ILogger, string, Exception> _roleAdded;
        private static readonly Action<ILogger, string, Exception> _addingRoleFailed;


        private static readonly Action<ILogger, Exception> _checkingIfAdminExists;
        private static readonly Action<ILogger, string, string, Exception> _creatingAdmin;
        private static readonly Action<ILogger, Exception> _creatingAdminFailed;
        private static readonly Action<ILogger, Exception> _addingRolesToAdmin;
        private static readonly Action<ILogger, Exception> _addingRolesToAdminFailed;

        static DataSeedLogger()
        {

            _addingNews = LoggerMessage.Define(
                 LogLevel.Debug,
                 new EventId(LoggingEvents.ListItems, nameof(AddingNews)),
                 "Adding the news...");

            _newsAdded = LoggerMessage.Define<int>(
                 LogLevel.Debug,
                 new EventId(LoggingEvents.ListItems, nameof(NewsAdded)),
                 "The news were added (Count = {Count}).");

            _checkingIfRolesExist = LoggerMessage.Define<IList<string>>(
                 LogLevel.Debug,
                 new EventId(LoggingEvents.CheckIfItemExists, nameof(CheckingIfRolesExist)),
                 "Checking if roles ({RoleNames}) exist.");

            _allRolesExistScope = LoggerMessage.DefineScope<int>("All roles exist (Count = {Count}).");

            _roleExists = LoggerMessage.Define<string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.CheckIfItemExists, nameof(RoleExists)),
                "Role <{RoleName}> exists.");

            _roleAdded = LoggerMessage.Define<string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(RoleAdded)),
                "Role <{RoleName}> was added.");

            _addingRoleFailed = LoggerMessage.Define<string>(
                LogLevel.Warning,
                new EventId(LoggingEvents.InsertItem, nameof(AddingRoleFailed)),
                "Adding role <{RoleName}> failed.");

            _checkingIfAdminExists = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.CheckIfItemExists, nameof(CheckingIfAdminExists)),
                "Checking if an admin exists...");

            _creatingAdmin = LoggerMessage.Define<string, string>(
                LogLevel.Debug,
                new EventId(LoggingEvents.GenerateItems, nameof(CreatingAdmin)),
                "Creating admin (Email = '{Email}', Password = '{Password}')...");

            _creatingAdminFailed = LoggerMessage.Define(
                LogLevel.Error,
                new EventId(LoggingEvents.GenerateItems, nameof(CreatingAdminFailed)),
                "Creating admin failed.");

            _addingRolesToAdmin = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(AddingRolesToAdmin)),
                "Adding all possible roles to admin...");

            _addingRolesToAdminFailed = LoggerMessage.Define(
                LogLevel.Error,
                new EventId(LoggingEvents.InsertItem, nameof(AddingRolesToAdminFailed)),
                "Adding roles to admin failed.");

        }

        public static void AddingNews(this ILogger logger)
        {
            _addingNews(logger, null);
        }

        public static void NewsAdded(this ILogger logger, int count)
        {
            _newsAdded(logger, count, null);
        }

        public static void CheckingIfRolesExist(this ILogger logger, IList<string> roleNames)
        {
            _checkingIfRolesExist(logger, roleNames, null);
        }

        public static IDisposable AllRolesExistScope(this ILogger logger, int count)
        {
            return _allRolesExistScope(logger, count);
        }

        public static void RoleExists(this ILogger logger, string roleName)
        {
            _roleExists(logger, roleName, null);
        }

        public static void RoleAdded(this ILogger logger, string roleName)
        {
            _roleAdded(logger, roleName, null);
        }

        public static void AddingRoleFailed(this ILogger logger, string roleName, Exception ex)
        {
            _addingRoleFailed(logger, roleName, ex);
        }

        public static void CheckingIfAdminExists(this ILogger logger)
        {
            _checkingIfAdminExists(logger, null);
        }

        public static void CreatingAdmin(this ILogger logger, string email, string password)
        {
            _creatingAdmin(logger, email, password, null);
        }

        public static void CreatingAdminFailed(this ILogger logger, Exception ex)
        {
            _creatingAdminFailed(logger, ex);
        }

        public static void AddingRolesToAdmin(this ILogger logger)
        {
            _addingRolesToAdmin(logger, null);
        }

        public static void AddingRolesToAdminFailed(this ILogger logger, Exception ex)
        {
            _addingRolesToAdminFailed(logger, ex);
        }
    }
}
