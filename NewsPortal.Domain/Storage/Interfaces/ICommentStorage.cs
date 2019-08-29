using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage.Interfaces
{
    public interface ICommentStorage
    {
        Task Add(CommentVM commentVM);
        Task Delete(Guid newsId, Guid userId);
        Task<Comment> Update(CommentVM commentVM);
        Task<Comment> Get(Guid newsId, Guid userId);
        Task<CommentsListVM> GetCommentsNews(Guid newsId, int count, int page);
        Task<CommentsListVM> GetCommentsUser(Guid userId, int count, int page);
    }
}
