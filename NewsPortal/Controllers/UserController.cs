using Microsoft.AspNetCore.Mvc;
using NewsPortal.Domain.Builder;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Filters;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : Controller
    {
        private readonly IUserStorage _userStorage;
        private readonly UserBuilder _userBuilder;

        public UserController(IUserStorage userStorage, UserBuilder userBuilder)
        {
            _userStorage = userStorage;
            _userBuilder = userBuilder;
        }

        /// <summary>
        /// Метод на получение информации по конкретному пользователю
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя</param>
        /// <returns>Модель искомого пользователя</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ApplicationUser> Get([FromRoute]Guid userId)
        {
            var news = await _userBuilder.Get(userId);
            return news;
        }

        ///// <summary>
        ///// Добавление нового пользователя
        ///// </summary>
        ///// <param name="RegisterVM">Модель нового пользователя</param>
        ///// <returns></returns>
        //[HttpPost]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ServiceFilter(typeof(AuthorizeFilterAttribute))]
        //public async Task<OperationResult> Add([FromBody]RegisterVM registerVM)
        //{
        //    var result = await _userBuilder.Add(registerVM);
        //    return result;
        //}

        /// <summary>
        /// Метод на редактирование пользователя
        /// </summary>
        /// <param name="ApplicationUserVM">Изменённая модель пользователя</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task Put([FromBody]ApplicationUserVM applicationUserVM)
        {
            await _userBuilder.Update(applicationUserVM);
        }

        /// <summary>
        /// Метод на удаление пользователя
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task Delete([FromRoute]Guid userId)
        {
            await _userStorage.Delete(userId);
        }
    }
}
