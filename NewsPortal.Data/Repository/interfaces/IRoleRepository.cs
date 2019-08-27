using Microsoft.AspNetCore.Identity;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository.interfaces
{
    public interface IRoleRepository
    {
        Task<ChangeRoleVM> Get(Guid id);
        Task<MyRoleVM> GetMyRole(string login);
        Task<IdentityResult> Create(string nameRole);
        Task<ApplicationUser> Update(Guid userId, List<string> roles);
        Task Delete(Guid roleId);
    }
}
