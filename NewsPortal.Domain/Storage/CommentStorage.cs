using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage
{
    public class CommentStorage : ICommentStorage
    {
        private readonly DataContext _context;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentStorage(DataContext context, ICommentRepository commentRepository, IMapper mapper)
        {
            _context = context;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task Add(CommentVM commentVM)
        {
            var comment = _mapper.Map<Comment>(commentVM);
            comment.CreateDate = DateTime.Now;
            await _commentRepository.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid newsId, Guid userId)
        {
            await _commentRepository.Delete(newsId, userId);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> Update(CommentVM commentVM)
        {
            var comment = _mapper.Map(commentVM, await _context.Comments.SingleAsync(c => (c.NewsId == commentVM.NewsId) && (c.UserId == commentVM.UserId)));
            comment.CreateDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return comment;
        }
        public async Task<Comment> Get(Guid newsId, Guid userId)
        {
            return await _commentRepository.Get(newsId, userId);
        }
    }
}

