using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Domain.Logging.LoggerExtensions.Main
{
    public static class ProgramLogger
    {
        private static readonly Action<ILogger, Exception> _migratingDatabase;
        private static readonly Action<ILogger, Exception> _migratingDatabaseFailed;
        private static readonly Action<ILogger, Exception> _databaseWasMigrated;
        private static readonly Action<ILogger, Exception> _seedingDatabase;
        private static readonly Action<ILogger, Exception> _seedingDatabaseFailed;
        private static readonly Action<ILogger, Exception> _databaseWasSeeded;
        private static readonly Action<ILogger, Exception> _runningWebHost;

        static ProgramLogger() {

            _migratingDatabase = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.MigrateDatabase, nameof(MigratingDatabase)),
               "Migrating the database...");

            _migratingDatabaseFailed = LoggerMessage.Define(
               LogLevel.Error,
               new EventId(LoggingEvents.MigrateDatabase, nameof(MigratingDatabaseFailed)),
               "Migrating the database failed.");

            _databaseWasMigrated = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.MigrateDatabase, nameof(DatabaseWasMigrated)),
               "The database was migrated.");

            _seedingDatabase = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.SeedDatabase, nameof(MigratingDatabase)),
               "Seeding the database...");

            _seedingDatabaseFailed = LoggerMessage.Define(
               LogLevel.Error,
               new EventId(LoggingEvents.SeedDatabase, nameof(MigratingDatabaseFailed)),
               "Seeding the database failed.");

            _databaseWasSeeded = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.SeedDatabase, nameof(DatabaseWasSeeded)),
               "The database was seeded.");

            _runningWebHost = LoggerMessage.Define(
               LogLevel.Debug,
               new EventId(LoggingEvents.RunWebHost, nameof(RunningWebHost)),
               "running web host...");
        }

        public static void MigratingDatabase(this ILogger logger) 
        {
            _migratingDatabase(logger, null);
        }

        public static void MigratingDatabaseFailed(this ILogger logger, Exception ex)
        {
            _migratingDatabaseFailed(logger, ex);
        }

        public static void DatabaseWasMigrated(this ILogger logger)
        {
            _databaseWasMigrated(logger, null);
        }

        public static void SeedingDatabase(this ILogger logger)
        {
            _seedingDatabase(logger, null);
        }

        public static void SeedingDatabaseFailed(this ILogger logger, Exception ex) 
        {
            _seedingDatabaseFailed(logger, ex);
        }

        public static void DatabaseWasSeeded(this ILogger logger) 
        {
            _databaseWasSeeded(logger, null);
        }

        public static void RunningWebHost(this ILogger logger) 
        {
            _runningWebHost(logger, null);
        }
    }
}   