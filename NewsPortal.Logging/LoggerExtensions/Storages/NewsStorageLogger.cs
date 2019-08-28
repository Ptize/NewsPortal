using Microsoft.Extensions.Logging;
using NewsPortal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Logging.LoggerExtensions.Storages
{
    public static class NewsStorageLogger
    {
        private const string StorageAccepts = "[NewsStorage] <=== ";
        private const string StorageReturns = "[NewsStorage] ===> ";

        private static readonly Action<ILogger, int, int, Exception> _getAllRequestReceived;
        private static readonly Action<ILogger, int, Exception> _getAllRequestReturnsNewsList;
        private static readonly Action<ILogger, Guid, Exception> _getRequestReceived;
        private static readonly Action<ILogger, Exception> _addRequestReceived;
        private static readonly Action<ILogger, Exception> _putRequestReceived;
        private static readonly Action<ILogger, Exception> _existingNewsFound;
        private static readonly Action<ILogger, Guid, Exception> _deleteRequestReceived;
        private static readonly Action<ILogger, Exception> _databaseExceptionReceived;

        static NewsStorageLogger()
        {
            _getAllRequestReceived = LoggerMessage.Define<int, int>(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReceived)),
                StorageAccepts + "[GetAll] with [NewsAmountOnPage = {CountEntity}] and [PageNumber = {Page}].");

            _getAllRequestReturnsNewsList = LoggerMessage.Define<int>(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReturnsNewsList)),
                StorageReturns + "[GetAll] returns news list and [PagesAmount = {PagesCount}].");

            _getRequestReceived = LoggerMessage.Define<Guid>(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(GetRequestReceived)),
                StorageAccepts + "[Get] with the [Id = {Id}].");

            _addRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(AddRequestReceived)),
                StorageAccepts + "[Add] with the [NewsVM].");

            _putRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReceived)),
                StorageAccepts + "[Update] with the [NewsVM].");

            _existingNewsFound = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(ExistingNewsFound)),
                "The existing news was found.");

            _deleteRequestReceived = LoggerMessage.Define<Guid>(
                LogLevel.Debug,
                new EventId(LoggingEvents.DeleteItem, nameof(DeleteRequestReceived)),
                StorageAccepts + "[Delete] with the [NewsId = {Id}].");

            _databaseExceptionReceived = LoggerMessage.Define(
               LogLevel.Error,
               new EventId(LoggingEvents.GetDatabaseException, nameof(DatabaseExceptionReceived)),
               "A database exception occured.");
        }
        public static void GetAllRequestReceived(this ILogger logger, int count, int page)
        {
            _getAllRequestReceived(logger, count, page, null);
        }

        public static void GetAllRequestReturnsNewsList(this ILogger logger, int pagesCount)
        {
            _getAllRequestReturnsNewsList(logger, pagesCount, null);
        }

        public static void GetRequestReceived(this ILogger logger, Guid id)
        {
            _getRequestReceived(logger, id, null);
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

        public static void DatabaseExceptionReceived(this ILogger logger, Exception ex)
        {
            _databaseExceptionReceived(logger, ex);
        }
    }
}
