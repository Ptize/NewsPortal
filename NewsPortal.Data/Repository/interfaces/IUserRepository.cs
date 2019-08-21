using NewsPortal.Models.Data;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository.interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> Get(string email);
        Task<ApplicationUser> Get(Guid id);
        Task Add(ApplicationUser user);
        Task Delete(Guid userId);
    }
}
