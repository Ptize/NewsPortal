using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Data
{
    public class NewsRepository :INewsRepository
    {
        private readonly DataContext _context;

        public NewsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(News news)
        {
            await _context.Newss.AddAsync(news);
        }

        public async Task Delete(Guid newsId)
        {
            var news = await _context.Newss.SingleAsync(n => n.NewsId == newsId);
            _context.Newss.Remove(news);
        }

        public async Task<int> Count()
        {
            return await _context.Newss.CountAsync();
        }

        public async Task<List<BriefNewsVM>> GetAll(int countEntity, int page)
        {
            var listBriefNewsVM = _context.Newss
                .Skip(countEntity * (page - 1))
                .Take(countEntity);

            var resListBriefNewsVM = (from i in listBriefNewsVM
                                      select new BriefNewsVM
                                      {
                                          NewsId = i.NewsId,
                                          CreateDate = i.CreateDate,
                                          Picture = i.Photo,
                                          Headline = i.Headline,
                                      }).ToListAsync();


            return await resListBriefNewsVM;
        }

        public async Task<News> Get(Guid newsId)
        {
            return await _context.Newss.SingleAsync(n => n.NewsId == newsId);
        }
    }
}
