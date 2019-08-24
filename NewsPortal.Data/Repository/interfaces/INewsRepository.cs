using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.interfaces
{
    public interface INewsRepository
    {
        Task<List<BriefNewsVM>> GetAll(int countEntity, int page);
        Task<News> Get(Guid newsId);
        Task Add(News news);
        Task Delete(Guid newsId);
        Task<int> Count();
    }
}
