using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsPortal.Data.interfaces;
using static NewsPortal.Logging.LoggerExtensions.Repositories.NewsRepositoryLogger;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly DataContext _context;
        private readonly ILogger _logger; 

        public NewsRepository(DataContext context, ILogger<NewsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<BriefNewsVM>> GetAll(int countEntity, int page)
        {
            _logger.GetAllRequestReceived(countEntity, page);
            var listBriefNewsVM = _context.Newss
                .AsNoTracking()
                .OrderBy(x => x.NewsId)
                .Skip(countEntity * (page - 1))
                .Take(countEntity);
            _logger.QueryDone($"Returns the list of [{countEntity}] news on [{page}] page");

            if (listBriefNewsVM == null)
            {
                _logger.GetAllRequestReturnsNewsList(0);
                return new List<BriefNewsVM>();
            }

            var resListBriefNewsVM = (from i in listBriefNewsVM
                                      select new BriefNewsVM
                                      {
                                          NewsId = i.NewsId,
                                          CreateDate = i.CreateDate,
                                          Picture = i.Photo,
                                          Headline = i.Headline,
                                      }).ToListAsync();
            _logger.QueryDone("Returns the list of news with specified fields (Id, CreateDate, Picture, Headline)");
            _logger.GetAllRequestReturnsNewsList(countEntity);
            return await resListBriefNewsVM;
        }

        public async Task<News> Get(Guid newsId)
        {
            _logger.GetRequestReceived(newsId);
            var news = await _context.Newss.AsNoTracking().SingleAsync(n => n.NewsId == newsId);
            _logger.QueryDone("Returns the news with specified id.");

            _logger.GetRequestReturns();
            return news;
        }

        public async Task Add(News news)
        {
            _logger.AddRequestReceived();
            await _context.Newss.AddAsync(news);
        }

        public async Task Delete(Guid newsId)
        {
            _logger.DeleteRequestReceived(newsId);
            var news = await _context.Newss.SingleAsync(n => n.NewsId == newsId);
            _logger.QueryDone("Returns the new with specified id.");

            _context.Newss.Remove(news);
        }

        public async Task<int> Count()
        {
            _logger.CountRequestReceived();
            var count = await _context.Newss.CountAsync();
            
            _logger.CountRequestReturns(count);
            return count;
        }

    }
}
