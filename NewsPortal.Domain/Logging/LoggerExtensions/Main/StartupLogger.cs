using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Domain.Logging.LoggerExtensions.Main
{
    public static class StartupLogger
    {
        private static readonly Action<ILogger, Exception> _addedSwagger;
        private static readonly Action<ILogger, Exception> _addedRepositories;
        private static readonly Action<ILogger, Exception> _addedStorages;
        private static readonly Action<ILogger, Exception> _addedBuilders;
        private static readonly Action<ILogger, Exception> _addedAutomapper;

        private static readonly Action<ILogger, Exception> _inDevelopment;

        static StartupLogger()
        {
            _addedSwagger = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.AddService, nameof(AddedSwagger)),
                "Added swagger to services.");

            _addedRepositories = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.AddService, nameof(AddedRepositories)),
                "Added the repositories to services.");

            _addedStorages = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.AddService, nameof(AddedStorages)),
                "Added the storages to services.");

            _addedBuilders = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.AddService, nameof(AddedBuilders)),
                "Added the builders to services.");

            _addedAutomapper = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.AddService, nameof(AddedAutomapper)),
                "Added automapper to services.");
            _inDevelopment = LoggerMessage.Define(
                LogLevel.Information,
                new EventId(LoggingEvents.DevelopmentMode, nameof(InDevelopment)),
                "In development environment");
        }

        public static void AddedSwagger(this ILogger logger)
        {
            _addedSwagger(logger, null);
        }

        public static void AddedRepositories(this ILogger logger)
        {
            _addedRepositories(logger, null);
        }

        public static void AddedStorages(this ILogger logger)
        {
            _addedStorages(logger, null);
        }

        public static void AddedBuilders(this ILogger logger)
        {
            _addedBuilders(logger, null);
        }

        public static void AddedAutomapper(this ILogger logger)
        {
            _addedAutomapper(logger, null);
        }

        public static void InDevelopment(this ILogger logger)
        {
            _inDevelopment(logger, null);
        }
    }
}
