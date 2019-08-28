using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Models.Data;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }

        public async Task Delete(Guid newsId, Guid userId)
        {
            var comment = await _context.Comments.SingleAsync(c =>(c.NewsId == newsId) && (c.UserId == userId));
            _context.Comments.Remove(comment);
        }

        public async Task<Comment> Get(Guid newsId, Guid userId)
        {
            return await _context.Comments.SingleAsync(c => (c.NewsId == newsId) && (c.UserId == userId));
        }
    }
}
