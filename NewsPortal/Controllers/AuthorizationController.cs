using Microsoft.AspNetCore.Mvc;
using NewsPortal.Data.Registration;
using NewsPortal.Filters;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly ExternalAuthorizationProvider _auth;
        private readonly UserContext _userContext;

        public AuthorizationController(ExternalAuthorizationProvider auth, UserContext userContext)
        {
            _auth = auth;
            _userContext = userContext;
        }

        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Информацию о пользователе и Sign в заголовке ответа</returns>
        [HttpGet("login={login}/password={password}")]
        public async Task<ApplicationUserVM> Authorization([FromRoute]string login, [FromRoute]string password)
        {
            var result = await _auth.Authorize(login, password);
            return result;
        }

        /// <summary>
        /// Метод проверки авторизации
        /// </summary>
        /// <returns>Идентификатор авторизованого пользователя</returns>
        [HttpGet]
        [ServiceFilter(typeof(ExternalAuthorizeFilterAttribute))]
        public async Task<string> AuthorizationCheck()
        {
            return _userContext.UserId.ToString();
        }

        /// <summary>
        /// Метод проверки роли в системе
        /// </summary>
        /// <returns>Роль авторизованного пользователя</returns>
        [HttpGet("RoleCheck")]
        [ServiceFilter(typeof(ExternalAuthorizeFilterAttribute)),
        TypeFilter(typeof(ExternalRoleFilterAttribute), Arguments = new object[] { Role.Developer })]
        public async Task<string> RoleCheck()
        {
            return _userContext.Role.ToString();
        }
    }
}
