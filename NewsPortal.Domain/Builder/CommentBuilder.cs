using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Builder
{
    /// <summary>
    /// Билдер для работы с методами комментариев. Данный билдер вызывается в контроллере новостей. И метод получения всех комментариев пользователя в контроллере пользователя(TODO)
    /// </summary>
    public class CommentBuilder
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentStorage _commentStorage;

        public CommentBuilder(ICommentRepository commentRepository, ICommentStorage commentStorage)
        {
            _commentRepository = commentRepository;
            _commentStorage = commentStorage;
        }

        public async Task<OperationResult> Add(CommentVM commentVM)
        {
            await _commentStorage.Add(commentVM);
            return OperationResult.Success;
        }

        public async Task<Comment> Get(Guid newsid, Guid userid)
        {
            return await _commentRepository.Get(newsid, userid);
        }

        public async Task<OperationResult> Update(CommentVM commentVM)
        {
            if ((!commentVM.NewsId.HasValue)&&(!commentVM.UserId.HasValue))
            {
                return OperationResult.InvalidId;
            }

            await _commentStorage.Update(commentVM);
            return OperationResult.Success;
        }
    }
}
