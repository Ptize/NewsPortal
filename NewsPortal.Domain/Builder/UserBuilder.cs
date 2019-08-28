using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPortal.Data.Repository.interfaces;
using static NewsPortal.Logging.LoggerExtensions.Builders.UserBuilderLogger;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Builder
{
    public class UserBuilder
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserStorage _userStorage;
        private readonly ILogger _logger; 

        public UserBuilder(IUserRepository userRepository, IUserStorage userStorage, ILogger<UserBuilder> logger)
        {
            _userRepository = userRepository;
            _userStorage = userStorage;
            _logger = logger;
        }

        public async Task<UsersListVM> GetAll(int countEntity, int page)
        {
            _logger.GetAllRequestReceived(countEntity, page);
            if (countEntity <= 0 || page <= 0)
            {
                UsersListVM listEmpty = new UsersListVM();
                _logger.GetAllRequestReturnsEmptyList();
                return listEmpty;
            }
            return await _userStorage.GetAll(countEntity, page);
        }

        public async Task<ApplicationUser> Get(Guid uid)
        {
            return await _userRepository.Get(uid);
        }

        public async Task<OperationResult> Add(RegisterVM registerVM, HttpContext httpContext, IUrlHelper Url)
        {
            _logger.AddRequestReceived(Url.Action());
            var result = await _userStorage.Add(registerVM, httpContext, Url);
            return result;
        }

        public async Task<OperationResult> Update(EditUserVM editUserVM)
        {
            _logger.PutRequestReceived();
            await _userStorage.Update(editUserVM);
            
            var result = OperationResult.Success;
            _logger.PutRequestReturns(result);
            return result;
        }

        public async Task<OperationResult> Login(LoginVM loginVM)
        {
            _logger.LoginRequestReceived();
            var result = await _userStorage.Login(loginVM);
            return result;
        }

        public async Task<OperationResult> Logout()
        {
            _logger.LogoutRequestReceived();
            var result = await _userStorage.Logout();
            return result;
        }

        public async Task<OperationResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            _logger.ChangePasswordRequestReceived();
            await _userStorage.ChangePassword(changePasswordVM);
            
            var result = OperationResult.Success;
            _logger.ChangePasswordRequestReturns(result);
            return result;
        }

        public async Task<OperationResult> ChangeForgotPassword(ChangeForgotPasswordVM changeForgotPasswordVM)
        {
            _logger.ChangeForgotPasswordRequestReceived();
            await _userStorage.ChangeForgotPassword(changeForgotPasswordVM);

            var result = OperationResult.Success;
            _logger.ChangeForgotPasswordRequestReturns(result);
            return result;
        }
    }
}
