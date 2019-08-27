using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPortal.Domain.Builder;
using NewsPortal.Domain.Logging.LoggerExtensions.Controllers;
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
    [Authorize(Roles = "editor, admin")]
    public class NewsController : Controller
    {
        private readonly INewsStorage _newsStorage;
        private readonly NewsBuilder _newsBuilder;
        private readonly ILogger _logger;
        private const string LoggerNewsEntity = "news";

        public NewsController(INewsStorage newsStorage, NewsBuilder newsBuilder, ILogger<NewsController> logger)
        {
            _newsStorage = newsStorage;
            _newsBuilder = newsBuilder;
            _logger = logger;
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
            _logger.GetAllRequestReceived("new");
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
            _logger.GetRequestReceived(LoggerNewsEntity);
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
            _logger.AddRequestReceived(LoggerNewsEntity);
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
            _logger.PutRequestReceived(LoggerNewsEntity);
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
            _logger.DeleteRequestReceived(LoggerNewsEntity);
            await _newsStorage.Delete(newsId);
        }
    }
        
    public class BlogController : Controller
    {
        private readonly ILogger _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Метод, отображающий стартовую страницу
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _logger.IndexPageRequestReceived();   
            return View(); // = ~/Views/Blog/Index.cshtml
        }
    }
}
