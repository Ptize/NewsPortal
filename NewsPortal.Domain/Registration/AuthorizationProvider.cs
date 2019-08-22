using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Registration
{
    public class AuthorizationProvider
    {
        private readonly IUserStorage _userStorage;

        public AuthorizationProvider(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public async Task<ApplicationUserVM> Authorize(string login, string password)
        {
            //TODO Запрос в БД на наличие зарегестрированного пользователя в result
            ApplicationUserVM result = null;

            if (result != null)
            {
                result = await UpdateUser(result);
            }

            return result;
        }

        public async Task<ApplicationUserVM> UpdateUser(ApplicationUserVM userVm)
        {
            //var user = await _userStorage.Get(userVm.Email);

            //await _userStorage.UpdateApiKey(user, userVm.Sign);

            return userVm;
        }
    }
}
