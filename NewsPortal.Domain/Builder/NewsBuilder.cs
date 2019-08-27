using NewsPortal.Data.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Builder
{
    public class NewsBuilder
    {
        private readonly INewsRepository _newsRepository;
        private readonly INewsStorage _newsStorage;

        public NewsBuilder(INewsRepository newsRepository, INewsStorage newsStorage)
        {
            _newsRepository = newsRepository;
            _newsStorage = newsStorage;
        }

        public async Task<OperationResult> Add(NewsVM newsVM)
        {
            await _newsStorage.Add(newsVM);
            return OperationResult.Success;
        }

        public async Task<NewsListVM> GetAll(int countEntity, int page)
        {
            if (countEntity <= 0 || page <= 0)
            {
                NewsListVM listEmpty = new NewsListVM();
                return listEmpty;
            }
            return await _newsStorage.GetAll(countEntity, page);
        }

        public async Task<News> Get(Guid newsid)
        {
            return await _newsRepository.Get(newsid);
        }

        public async Task<OperationResult> Update(NewsVM newsVM)
        {
            if (!newsVM.NewsId.HasValue)
            {
                return OperationResult.InvalidId;
            }

            await _newsStorage.Update(newsVM);
            return OperationResult.Success;
        }

    }
}
