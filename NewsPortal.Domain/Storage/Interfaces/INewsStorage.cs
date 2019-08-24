using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage.Interfaces
{
    public interface INewsStorage
    {
        Task Add(NewsVM newsVM);
        Task Delete(Guid newsId);
        Task<News> Update(NewsVM newsVM);
        Task<NewsListVM> GetAll(int count, int page);
        Task<News> Get(Guid newsId);
    }
}
