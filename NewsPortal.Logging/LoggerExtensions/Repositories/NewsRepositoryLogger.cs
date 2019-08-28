using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Logging.LoggerExtensions.Repositories
{
    public static class NewsRepositoryLogger
    {
        private const string RepositoryAccepts = "[NewsRepository] <=== ";
        private const string RepositoryReturns = "[NewsRepository] ===> ";

        private static readonly Action<ILogger, int, int, Exception> _getAllRequestReceived;
        private static readonly Action<ILogger, int, Exception> _getAllRequestReturnsNewsList;
        private static readonly Action<ILogger, Guid, Exception> _getRequestReceived;
        private static readonly Action<ILogger, Exception> _getRequestReturns;
        private static readonly Action<ILogger, Exception> _addRequestReceived;
        private static readonly Action<ILogger, Exception> _putRequestReceived;
        private static readonly Action<ILogger, Exception> _existingNewsFound;
        private static readonly Action<ILogger, Guid, Exception> _deleteRequestReceived;
        private static readonly Action<ILogger, Exception> _countRequestReceived;
        private static readonly Action<ILogger, int, Exception> _countRequestReturns;
        private static readonly Action<ILogger, Exception> _databaseExceptionReceived;
        private static readonly Action<ILogger, string, Exception> _queryDone;
        private static readonly Action<ILogger, string, Exception> _modifyingDatabase;

        static NewsRepositoryLogger()
        {
            _getAllRequestReceived = LoggerMessage.Define<int, int>(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReceived)),
                RepositoryAccepts + "[GetAll] with [NewsAmountOnPage = {CountEntity}] and [PageNumber = {Page}].");

            _getAllRequestReturnsNewsList = LoggerMessage.Define<int>(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReturnsNewsList)),
                RepositoryReturns + "[GetAll] returns news list (Count = {Count}).");

            _getRequestReceived = LoggerMessage.Define<Guid>(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(GetRequestReceived)),
                RepositoryAccepts + "[Get] with the [Id = {Id}].");

            _getRequestReturns = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(GetRequestReturns)),
                RepositoryReturns + "[Get] returns the news.");

            _addRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(AddRequestReceived)),
                RepositoryAccepts + "[Add] with the [NewsVM].");

            _putRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReceived)),
                RepositoryAccepts + "[Update] with the [NewsVM].");

            _existingNewsFound = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(ExistingNewsFound)),
                "The existing news was found.");

            _deleteRequestReceived = LoggerMessage.Define<Guid>(
                LogLevel.Debug,
                new EventId(LoggingEvents.DeleteItem, nameof(DeleteRequestReceived)),
                RepositoryAccepts + "[Delete] with the [NewsId = {Id}].");

            _countRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.DoQuery, nameof(CountRequestReceived)),
                RepositoryAccepts + "[Count] with none parameters.");

            _countRequestReturns = LoggerMessage.Define<int>(
               LogLevel.Debug,
               new EventId(LoggingEvents.DoQuery, nameof(CountRequestReturns)),
               RepositoryReturns + "[Count] returns [NewsCount = {Count}].");

            _databaseExceptionReceived = LoggerMessage.Define(
               LogLevel.Error,
               new EventId(LoggingEvents.GetDatabaseException, nameof(DatabaseExceptionReceived)),
               "A database exception occured.");

            _queryDone = LoggerMessage.Define<string>(
               LogLevel.Debug,
               new EventId(LoggingEvents.DoQuery, nameof(QueryDone)),
               "Query was done [Query description = '{Query}'].");

            _modifyingDatabase = LoggerMessage.Define<string>(
               LogLevel.Debug,
               new EventId(LoggingEvents.ModifyDatabase, nameof(ModifyingDatabase)),
               "Modifying database... [Description = '{Query}'.");
        }
        public static void GetAllRequestReceived(this ILogger logger, int count, int page)
        {
            _getAllRequestReceived(logger, count, page, null);
        }

        public static void GetAllRequestReturnsNewsList(this ILogger logger, int newsCount)
        {
            _getAllRequestReturnsNewsList(logger, newsCount, null);
        }

        public static void GetRequestReceived(this ILogger logger, Guid id)
        {
            _getRequestReceived(logger, id, null);
        }

        public static void GetRequestReturns(this ILogger logger)
        {
            _getRequestReturns(logger, null);
        }

        public static void AddRequestReceived(this ILogger logger)
        {
            _addRequestReceived(logger, null);
        }

        public static void PutRequestReceived(this ILogger logger)
        {
            _putRequestReceived(logger, null);
        }

        public static void ExistingNewsFound(this ILogger logger)
        {
            _existingNewsFound(logger, null);
        }

        public static void DeleteRequestReceived(this ILogger logger, Guid id)
        {
            _deleteRequestReceived(logger, id, null);
        }

        public static void CountRequestReceived(this ILogger logger)
        {
            _countRequestReceived(logger, null);
        }

        public static void CountRequestReturns(this ILogger logger, int newsCount)
        {
            _countRequestReturns(logger, newsCount, null);
        }

        public static void DatabaseExceptionReceived(this ILogger logger, Exception ex)
        {
            _databaseExceptionReceived(logger, ex);
        }

        public static void QueryDone(this ILogger logger, string query)
        {
            _queryDone(logger, query, null);
        }

        public static void ModifyingDatabase(this ILogger logger, string description)
        {
            _modifyingDatabase(logger, description, null);
        }
    }
}
