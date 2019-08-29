using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> CountNewsId(Guid newsId)
        {
            return await _context.Comments.CountAsync(c => c.NewsId == newsId);
        }

        public async Task<List<Comment>> GetCommentsNews(Guid newsId, int countEntity, int page)
        {
            var listComment = _context.Comments
                .Where(c => c.UserId == newsId)
                .Skip(countEntity * (page - 1))
                .Take(countEntity);

            var resListComment = (from i in listComment
                                      select new Comment
                                      {
                                          NewsId = i.NewsId,
                                          CreateDate = i.CreateDate,
                                          UserId = i.UserId,
                                          Text = i.Text
                                      }).ToListAsync();

            return await resListComment;
        }

        public async Task<int> CountUserId(Guid userId)
        {
            return await _context.Comments.CountAsync(c => c.UserId == userId);
        }

        public async Task<List<Comment>> GetCommentsUser(Guid userId, int countEntity, int page)
        {
            var listComment = _context.Comments
                .Where(c => c.UserId == userId)
                .Skip(countEntity * (page - 1))
                .Take(countEntity);

            var resListComment = (from i in listComment
                                  select new Comment
                                  {
                                      NewsId = i.NewsId,
                                      CreateDate = i.CreateDate,
                                      UserId = i.UserId,
                                      Text = i.Text
                                  }).ToListAsync();

            return await resListComment;
        }
    }
}
