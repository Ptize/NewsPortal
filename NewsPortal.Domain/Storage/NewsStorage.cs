using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Data.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage
{
    public class NewsStorage : INewsStorage
    {
        private readonly DataContext _context;
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public NewsStorage(DataContext context, INewsRepository newsRepository, IMapper mapper)
        {
            _context = context;
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task Add(NewsVM newsVM)
        {
            var news = _mapper.Map<News>(newsVM);
            news.CreateDate = DateTime.Now;
            await _newsRepository.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid newsId)
        {
            await _newsRepository.Delete(newsId);
            await _context.SaveChangesAsync();
        }

        public async Task<News> Update(NewsVM newsVM)
        {
            var news = _mapper.Map(newsVM, await _context.Newss.SingleAsync(n => n.NewsId == newsVM.NewsId));
            news.CreateDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task<NewsListVM> GetAll()
        {
            var news = new NewsListVM
            {
                NewsList = await _newsRepository.GetAll()
            };
            return news;
        }

        public async Task<News> Get(Guid newsId)
        {
            return await _newsRepository.Get(newsId);
        }
    }
}
