using Microsoft.Extensions.Logging;
using NewsPortal.Data.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;
using static NewsPortal.Logging.LoggerExtensions.Builders.NewsBuilderLogger;

namespace NewsPortal.Domain.Builder
{
    public class NewsBuilder
    {
        private readonly INewsRepository _newsRepository;
        private readonly INewsStorage _newsStorage;
        private readonly ILogger _logger;

        public NewsBuilder(INewsRepository newsRepository, INewsStorage newsStorage, ILogger<NewsBuilder> logger)
        {
            _newsRepository = newsRepository;
            _newsStorage = newsStorage;
            _logger = logger;
        }

        public async Task<OperationResult> Add(NewsVM newsVM)
        {
            _logger.AddRequestReceived();
            await _newsStorage.Add(newsVM);

            var result = OperationResult.Success;
            _logger.AddRequestReturns(result);
            return result;
        }

        public async Task<NewsListVM> GetAll(int countEntity, int page)
        {
            _logger.GetAllRequestReceived(countEntity, page);
            if (countEntity <= 0 || page <= 0)
            {
                NewsListVM listEmpty = new NewsListVM();
                _logger.GetAllRequestReturnsEmptyList();
                return listEmpty;
            }
            return await _newsStorage.GetAll(countEntity, page);
        }

        public async Task<News> Get(Guid newsId)
        {
            _logger.GetRequestReceived(newsId);
            return await _newsRepository.Get(newsId);
        }

        public async Task<OperationResult> Update(NewsVM newsVM)
        {
            _logger.PutRequestReceived();
            var result = OperationResult.InvalidId;
            if (!newsVM.NewsId.HasValue)
            {
                _logger.PutRequestReturns(result);
                return result;
            }

            await _newsStorage.Update(newsVM);

            result = OperationResult.Success;
            _logger.PutRequestReturns(result);
            return result;
        }

    }
}
