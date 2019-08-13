using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetAll();
        Task<News> Get(Guid newsId);
        Task Add(News news);
        Task Delete(Guid newsId);
    }
}
