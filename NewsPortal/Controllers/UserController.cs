using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPortal.Data.Repository.interfaces;
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
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IUserStorage _userStorage;
        private readonly UserBuilder _userBuilder;
        private readonly ILogger _logger;
        private const string LoggerUserEntity = "user";
        private readonly IUserRepository _userRepository;

        public UserController(IUserStorage userStorage, UserBuilder userBuilder, IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userStorage = userStorage;
            _userBuilder = userBuilder;
            _userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Метод на получение списка пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        [HttpGet("list/pageSize={count}/pageNum={page}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<UsersListVM> GetAll([FromRoute]int count, [FromRoute]int page)
        {
            _logger.GetAllRequestReceived(LoggerUserEntity);
            var news = await _userBuilder.GetAll(count, page);
            return news;
        }

        /// <summary>
        /// Метод на получение информации по конкретному пользователю
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <returns>Модель искомого пользователя</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ApplicationUser> Get([FromRoute]Guid userId)
        {
            _logger.GetRequestReceived(LoggerUserEntity);
            var user = await _userBuilder.Get(userId);
            return user;
        }

        /// <summary>
        /// Добавление нового пользователя (РЕГИСТРАЦИЯ)
        /// </summary>
        /// <param name="registerVM">Модель нового пользователя</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<OperationResult> Add([FromBody]RegisterVM registerVM)
        {
            var result = await _userBuilder.Add(registerVM, HttpContext, Url);
            return result;
        }
        
        /// <summary>
        /// Подтверждение Email
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <param name="code">подтверждающий токен</param>
        /// <returns></returns>
        [HttpGet("confirmemail/userId={userId}/code={code}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<bool> ConfirmEmail([FromRoute]Guid userId, [FromRoute]string code)
        {
            var result = await _userRepository.ConfirmEmail(userId, code);
            return result;
        }

        /// <summary>
        /// Метод на редактирование пользователя
        /// </summary>
        /// <param name="editUserVM">Изменённая модель пользователя</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task Put([FromBody]EditUserVM editUserVM)
        {
            _logger.PutRequestReceived(LoggerUserEntity);
            await _userBuilder.Update(editUserVM);
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
            _logger.DeleteRequestReceived(LoggerUserEntity);
            await _userStorage.Delete(userId);
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="loginVM">Модель login</param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<OperationResult> Login([FromBody]LoginVM loginVM)
        {
            _logger.LoginRequestReceived();
            var result = await _userBuilder.Login(loginVM);
            return result;
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<OperationResult> Logout()
        {
            _logger.LogoutRequestReceived();
            var result = await _userBuilder.Logout();
            return result;
        }

        /// <summary>
        /// Изменение пароля пользователя
        /// </summary>
        /// <param name="changePasswordVM">Модель изменения пароля</param>
        /// <returns></returns>
        [HttpPost("ChangePassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "user")]
        public async Task<OperationResult> ChangePassword([FromBody]ChangePasswordVM changePasswordVM)
        {
            _logger.ChangePasswordRequestReceived();
            var result = await _userBuilder.ChangePassword(changePasswordVM);
            return result;
        }

        /// <summary>
        /// Изменение пароля пользователя на случай если забыл пароль
        /// </summary>
        /// <param name="сhangeForgotPasswordVM">Модель изменения пароля</param>
        /// <returns></returns>
        [HttpPost("ChangeForgotPassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<OperationResult> ChangeForgotPassword([FromBody]ChangeForgotPasswordVM сhangeForgotPasswordVM)
        {
            _logger.ChangeForgotPasswordRequestReceived();
            var result = await _userBuilder.ChangeForgotPassword(сhangeForgotPasswordVM);
            return result;
        }

       
    }
}
