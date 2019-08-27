using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage.Interfaces
{
    public interface IUserStorage
    {
        Task<UsersListVM> GetAll(int count, int page);
        Task<OperationResult> Add(RegisterVM registerVM, HttpContext httpContext, IUrlHelper Url);
        Task<ApplicationUser> Update(EditUserVM editUserVM);
        Task Delete(Guid userId);
        Task<ApplicationUser> Get(Guid id);
        Task<ApplicationUser> Get(string email);
        Task<OperationResult> Login(LoginVM loginVM);
        Task<OperationResult> Logout();
        Task<OperationResult> ChangePassword(ChangePasswordVM changePasswordVM);
        Task<OperationResult> ChangeForgotPassword(ChangeForgotPasswordVM changeForgotPasswordVM);
    }
}
