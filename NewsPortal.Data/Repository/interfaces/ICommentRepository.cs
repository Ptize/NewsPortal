using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository.interfaces
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);
        Task Delete(Guid newsId, Guid userId);
        Task<Comment> Get(Guid newsId, Guid userId);
        Task<int> CountNewsId(Guid newsId);
        Task<List<Comment>> GetCommentsNews(Guid newsId, int countEntity, int page);
        Task<int> CountUserId(Guid userId);
        Task<List<Comment>> GetCommentsUser(Guid userId, int countEntity, int page);
    }
}
