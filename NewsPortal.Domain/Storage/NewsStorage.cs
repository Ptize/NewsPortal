using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsPortal.Data;
using NewsPortal.Data.interfaces;
using static NewsPortal.Logging.LoggerExtensions.Storages.NewsStorageLogger;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage
{
    public class NewsStorage : INewsStorage
    {
        private readonly DataContext _context;
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger; 

        public NewsStorage(DataContext context, INewsRepository newsRepository, IMapper mapper, ILogger<NewsStorage> logger)
        {
            _context = context;
            _newsRepository = newsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<NewsListVM> GetAll(int count, int page)
        {
            _logger.GetAllRequestReceived(count, page);
            var countEntity = await _newsRepository.Count();

            var news = new NewsListVM
            {
                CountPage = countEntity % count == 0 ? countEntity / count : (countEntity / count) + 1,
                NewsList = await _newsRepository.GetAll(count, page)
            };
            _logger.GetAllRequestReturnsNewsList(news.CountPage);
            return news;
        }

        public async Task<News> Get(Guid newsId)
        {
            _logger.GetRequestReceived(newsId);
            return await _newsRepository.Get(newsId);
        }

        public async Task Add(NewsVM newsVM)
        {
            _logger.AddRequestReceived();
            var news = _mapper.Map<News>(newsVM);
            news.CreateDate = DateTime.Now;
            await _newsRepository.Add(news);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.DatabaseExceptionReceived(ex);
            }
        }

        public async Task<News> Update(NewsVM newsVM)
        {
            _logger.PutRequestReceived();
            try
            {
                var dest = await _context.Newss.SingleAsync(n => n.NewsId == newsVM.NewsId);
                _logger.ExistingNewsFound();
                var news = _mapper.Map(newsVM, dest);
                news.CreateDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return news;
            }
            catch (Exception ex)
            {
                _logger.DatabaseExceptionReceived(ex);
            }
            return null;
        }

        public async Task Delete(Guid newsId)
        {
            _logger.DeleteRequestReceived(newsId);
            await _newsRepository.Delete(newsId);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.DatabaseExceptionReceived(ex);
            }
        }


    }
}
