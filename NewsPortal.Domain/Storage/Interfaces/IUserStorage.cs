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
        Task<OperationResult> Add(RegisterVM registerVM);
        Task<ApplicationUser> Update(ApplicationUserVM authVm);
        Task Delete(Guid userId);
        Task<ApplicationUser> Get(Guid id);
        Task<ApplicationUser> Get(string email);
        Task<OperationResult> Login(LoginVM loginVM);
        Task<OperationResult> Logout();
    }
}
