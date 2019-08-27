using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Data.Repository.interfaces;
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

        public UserBuilder(IUserRepository userRepository, IUserStorage userStorage)
        {
            _userRepository = userRepository;
            _userStorage = userStorage;
        }

        public async Task<UsersListVM> GetAll(int countEntity, int page)
        {
            if (countEntity <= 0 || page <= 0)
            {
                UsersListVM listEmpty = new UsersListVM();
                return listEmpty;
            }
            else
                return await _userStorage.GetAll(countEntity, page);
        }

        public async Task<OperationResult> Add(RegisterVM registerVM, HttpContext httpContext, IUrlHelper Url)
        {
            var result = await _userStorage.Add(registerVM, httpContext, Url);
            return result;
        }

        public async Task<ApplicationUser> Get(Guid newsid)
        {
            return await _userRepository.Get(newsid);
        }

        public async Task<OperationResult> Update(EditUserVM editUserVM)
        {
            await _userStorage.Update(editUserVM);
            return OperationResult.Success;
        }

        public async Task<OperationResult> Login(LoginVM loginVM)
        {
            var result = await _userStorage.Login(loginVM);
            return result;
        }

        public async Task<OperationResult> Logout()
        {
            var result = await _userStorage.Logout();
            return result;
        }

        public async Task<OperationResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            await _userStorage.ChangePassword(changePasswordVM);
            return OperationResult.Success;
        }

        public async Task<OperationResult> ChangeForgotPassword(ChangeForgotPasswordVM changeForgotPasswordVM)
        {
            await _userStorage.ChangeForgotPassword(changeForgotPasswordVM);
            return OperationResult.Success;
        }
    }
}
