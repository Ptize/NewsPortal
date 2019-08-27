﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly NewsBuilder _newsBuilder;

        public NewsController(INewsStorage newsStorage, NewsBuilder newsBuilder)
        {
            _newsStorage = newsStorage;
            _newsBuilder = newsBuilder;
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
