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
    [Authorize(Roles = "admin")]
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
        /// Метод на получение списка пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        [HttpGet("list/pageSize={count}/pageNum={page}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<UsersListVM> GetAll([FromRoute]int count, [FromRoute]int page)
        {
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
            var result = await _userBuilder.Add(registerVM);
            return result;
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
        public async Task<OperationResult> ChangePassword([FromBody]ChangePasswordVM changePasswordVM)
        {
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
        public async Task<OperationResult> ChangeForgotPassword([FromBody]ChangeForgotPasswordVM сhangeForgotPasswordVM)
        {
            var result = await _userBuilder.ChangeForgotPassword(сhangeForgotPasswordVM);
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
            await _userStorage.Delete(userId);
        }
    }
}
