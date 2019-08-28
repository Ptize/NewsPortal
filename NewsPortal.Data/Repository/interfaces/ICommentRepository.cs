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
    }
}
