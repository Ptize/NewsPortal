using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPortal.Domain.Builder;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsPortal.Domain.Logging.LoggerExtensions.Controllers;

namespace NewsPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RolesController:Controller
    {
        private readonly IRoleStorage _roleStorage;
        private readonly RoleBuilder _roleBuilder;
        private readonly ILogger _logger;
        private const string LoggerRoleEntity = "role";

        public RolesController(IRoleStorage roleStorage, RoleBuilder roleBuilder, ILogger<RolesController> logger)
        {
            _roleStorage = roleStorage;
            _roleBuilder = roleBuilder;
            _logger = logger;
        }

        /// <summary>
        /// Метод на получение информации по ролям конкретного пользователя
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя</param>
        /// <returns>Модель искомого изменяемой роли</returns>
        [HttpGet("{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "admin")]
        public async Task<ChangeRoleVM> Get([FromRoute]Guid userId)
        {
            _logger.GetRequestReceived(LoggerRoleEntity);
            var role = await _roleBuilder.Get(userId);
            return role;
        }

        /// <summary>
        /// Метод на получение информации по ролям конкретного пользователя через логин
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Модель искомого изменяемой роли</returns>
        [HttpGet("{login}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Authorize(Roles = "user")]
        public async Task<MyRoleVM> GetMyRole([FromRoute]string login)
        {
            var role = await _roleBuilder.GetMyRole(login);
            return role;
        }

        /// <summary>
        /// Добавление новой роли в систему
        /// </summary>
        /// <param name="nameRole">Название новой роли</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "admin")]
        public async Task<OperationResult> Add([FromBody]string nameRole)
        {
            _logger.AddRequestReceived(LoggerRoleEntity);
            var result = await _roleBuilder.Add(nameRole);
            return result;
        }

        /// <summary>
        /// Метод для изменения ролей пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="roles">Список ролей пользователя (которые у него должны быть)</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "admin")]
        public async Task Put([FromBody]Guid userId, List<string> roles)
        {
            _logger.PutRequestReceived(LoggerRoleEntity);
            await _roleBuilder.Update(userId, roles);
        }

        /// <summary>
        /// Метод на удаление роли
        /// </summary>
        /// <param name="roleId">Уникальный идентификатор роли</param>
        /// <returns></returns>
        [HttpDelete("{roleId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "admin")]
        public async Task Delete([FromRoute]Guid roleId)
        {
            _logger.DeleteRequestReceived(LoggerRoleEntity);
            await _roleStorage.Delete(roleId);
        }
    }
}
