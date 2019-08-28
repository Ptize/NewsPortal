using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Domain.Builder;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NewsController :Controller
    {
        private readonly INewsStorage _newsStorage;
        private readonly ICommentStorage _commentStorage;
        private readonly NewsBuilder _newsBuilder;
        private readonly CommentBuilder _commentBuilder;

        public NewsController(INewsStorage newsStorage, NewsBuilder newsBuilder, CommentBuilder commentBuilder, ICommentStorage commentStorage)
        {
            _newsStorage = newsStorage;
            _newsBuilder = newsBuilder;
            _commentBuilder = commentBuilder;
            _commentStorage = commentStorage;
        }

        /// <summary>
        /// Метод на получение списка новостей
        /// </summary>
        /// <returns>Список всех новостей</returns>
        [HttpGet("list/pageSize={count}/pageNum={page}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<NewsListVM> GetAll([FromRoute]int count, [FromRoute]int page)
        {
            var news = await _newsBuilder.GetAll(count, page);
            return news;
        }

        /// <summary>
        /// Метод на получение информации по конкретной новости
        /// </summary>
        /// <param name="newsId">Уникальный идентификатор новости</param>
        /// <returns>Модель искомой новости</returns>
        [HttpGet("{newsId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "user")]
        public async Task<News> Get([FromRoute]Guid newsId)
        {
            var news = await _newsBuilder.Get(newsId);
            return news;
        }

        /// <summary>
        /// Добавление новой новости
        /// </summary>
        /// <param name="newsVM">Модель новой новости</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "editor, admin")]
        public async Task<OperationResult> Add([FromBody]NewsVM newsVM)
        {
            var result = await _newsBuilder.Add(newsVM);
            return result;
        }

        /// <summary>
        /// Метод на редактирование новости
        /// </summary>
        /// <param name="newsVM">Изменённая модель новости</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "editor, admin")]
        public async Task Put([FromBody]NewsVM newsVM)
        {
            await _newsBuilder.Update(newsVM);
        }

        /// <summary>
        /// Метод на удаление новости
        /// </summary>
        /// <param name="newsId">Уникальный идентификатор новости</param>
        /// <returns></returns>
        [HttpDelete("{newsId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "editor, admin")]
        public async Task Delete([FromRoute]Guid newsId)
        {
            await _newsStorage.Delete(newsId);
        }

        /// <summary>
        /// Метод на получение информации по конкретному комментарию
        /// </summary>
        /// <param name="newsId">Уникальный идентификатор новости</param>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <returns>Модель искомого комментария</returns>
        [HttpGet("getComment/newsId={newsId}/userId={userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "user")]
        public async Task<Comment> Get([FromRoute]Guid newsId, [FromRoute]Guid userId)
        {
            var comment = await _commentBuilder.Get(newsId, userId);
            return comment;
        }

        /// <summary>
        /// Добавление нового комментария
        /// </summary>
        /// <param name="commentVM">Модель нового комментария</param>
        /// <returns></returns>
        [HttpPost("newComment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "user")]
        public async Task<OperationResult> Add([FromBody]CommentVM commentVM)
        {
            var result = await _commentBuilder.Add(commentVM);
            return result;
        }

        /// <summary>
        /// Метод на редактирование комментария
        /// </summary>
        /// <param name="commentVM">Изменённая модель комментария</param>
        /// <returns></returns>
        [HttpPut("updeteComment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "user")]
        public async Task Put([FromBody]CommentVM commentVM)
        {
            await _commentBuilder.Update(commentVM);
        }

        /// <summary>
        /// Метод на удаление комментария
        /// </summary>
        /// <param name="newsId">Уникальный идентификатор новости</param>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <returns></returns>
        [HttpDelete("remove/newsId={newsId}/userId={userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "admin")]
        public async Task Delete([FromRoute]Guid newsId, [FromRoute]Guid userId)
        {
            await _commentStorage.Delete(newsId, userId);
        }
    }
        
    public class BlogController : Controller
    {
        /// <summary>
        /// Метод, отображающий стартовую страницу
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(); // = ~/Views/Blog/Index.cshtml
        }
    }
}
