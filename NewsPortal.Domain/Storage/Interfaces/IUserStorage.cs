using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage.Interfaces
{
    public interface IUserStorage
    {
        Task Add(ApplicationUserVM authVm);
        Task<ApplicationUser> Update(ApplicationUserVM authVm);
        Task Delete(Guid userId);
        Task<ApplicationUser> Get(Guid id);
        Task<ApplicationUser> Get(string email);
        Task UpdateApiKey(ApplicationUser user, string apiKey);
    }
}
