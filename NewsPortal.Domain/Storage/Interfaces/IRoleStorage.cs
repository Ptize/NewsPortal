using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage.Interfaces
{
    public interface IRoleStorage
    {
        Task<OperationResult> Add(string nameRole);
        Task<ApplicationUser> Update(Guid userId, List<string> roles);
        Task Delete(Guid roleId);
    }
}
