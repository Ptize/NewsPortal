using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Builder
{
    public class RoleBuilder
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleStorage _roleStorage;

        public RoleBuilder(IRoleRepository roleRepository, IRoleStorage roleStorage)
        {
            _roleRepository = roleRepository;
            _roleStorage = roleStorage;
        }

        public async Task<ChangeRoleVM> Get(Guid userid)
        {
            return await _roleRepository.Get(userid);
        }
        public async Task<MyRoleVM> GetMyRole(string login)
        {
            return await _roleRepository.GetMyRole(login);
        }

        public async Task<OperationResult> Add(string nameRole)
        {
            var result = await _roleStorage.Add(nameRole);
            return result;
        }

        public async Task<OperationResult> Update(Guid userId, List<string> roles)
        {
            await _roleStorage.Update(userId, roles);
            return OperationResult.Success;
        }
    }
}
