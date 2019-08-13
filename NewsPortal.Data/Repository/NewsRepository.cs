using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.interfaces;
using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<List<News>> GetAll()
        {
            var newss = await _context.Newss
                .ToListAsync();

            return newss;
        }

        public async Task<News> Get(Guid newsId)
        {
            return await _context.Newss.SingleAsync(n => n.NewsId == newsId);
        }
    }
}
