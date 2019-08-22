using Microsoft.AspNetCore.Identity;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository.interfaces
{
    public interface IUserRepository
    {
        Task<int> Count();
        Task<List<BriefUserVM>> GetAll(int countEntity, int page);
        Task<ApplicationUser> Get(string email);
        Task<ApplicationUser> Get(Guid id);
        Task<IdentityResult> Add(ApplicationUser user, string password);
        Task<ApplicationUser> Update(EditUserVM editUserVM);
        Task Delete(Guid userId);
        Task<IdentityResult> UpdatePassword(ChangePasswordVM changePasswordVM);
        Task<IdentityResult> UpdateForgotPassword(ChangeForgotPasswordVM changeForgotPasswordVM);
    }
}
