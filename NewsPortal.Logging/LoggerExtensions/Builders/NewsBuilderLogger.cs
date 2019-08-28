using Microsoft.Extensions.Logging;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Logging.LoggerExtensions.Builders
{
    public static class NewsBuilderLogger
    {
        private const string BuilderAccepts = "[NewsBuilder] <=== ";
        private const string BuilderReturns = "[NewsBuilder] ===> ";

        private static readonly Action<ILogger, int, int, Exception> _getAllRequestReceived;
        private static readonly Action<ILogger, Exception> _getAllRequestReturnsEmptyList;
        private static readonly Action<ILogger, Guid, Exception> _getRequestReceived;
        private static readonly Action<ILogger, Exception> _addRequestReceived;
        private static readonly Action<ILogger, OperationResult, Exception> _addRequestReturns;
        private static readonly Action<ILogger, Exception> _putRequestReceived;
        private static readonly Action<ILogger, OperationResult, Exception> _putRequestReturns;

        static NewsBuilderLogger()
        {
            _getAllRequestReceived = LoggerMessage.Define<int, int>(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReceived)),
                BuilderAccepts + "[GetAll] with [NewsAmountOnPage = {CountEntity}] and [PageNumber = {Page}].");

            _getAllRequestReturnsEmptyList = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.ListItems, nameof(GetAllRequestReturnsEmptyList)),
                BuilderReturns + "[GetAll] returns empty list.");

            _getRequestReceived = LoggerMessage.Define<Guid>(
                LogLevel.Debug,
                new EventId(LoggingEvents.GetItem, nameof(GetRequestReceived)),
                BuilderAccepts + "[Get] with the [Id = {Id}].");

            _addRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(AddRequestReceived)),
                BuilderAccepts + "[Add] with the [NewsVM].");

            _addRequestReturns = LoggerMessage.Define<OperationResult>(
                LogLevel.Debug,
                new EventId(LoggingEvents.InsertItem, nameof(AddRequestReturns)),
                BuilderReturns + "[Add] returns [OperationResult = {OperationResult}].");

            _putRequestReceived = LoggerMessage.Define(
                LogLevel.Debug,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReceived)),
                BuilderAccepts + "[Update] with the [NewsVM].");

            _putRequestReturns = LoggerMessage.Define<OperationResult>(
                LogLevel.Debug,
                new EventId(LoggingEvents.UpdateItem, nameof(PutRequestReturns)),
                BuilderReturns + "[Update] returns [OperationResult = {OperationResult}].");

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

        public static void AddRequestReceived(this ILogger logger)
        {
            _addRequestReceived(logger, null);
        }

        public static void AddRequestReturns(this ILogger logger, OperationResult operationResult)
        {
            _addRequestReturns(logger, operationResult, null);
        }

        public static void PutRequestReceived(this ILogger logger)
        {
            _putRequestReceived(logger, null);
        }

        public static void PutRequestReturns(this ILogger logger, OperationResult operationResult)
        {
            _putRequestReturns(logger, operationResult, null);
        }
    }
}
