using NewsPortal.Data;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage
{
    public class RoleStorage : IRoleStorage
    {
        private readonly DataContext _context;
        private readonly IRoleRepository _roleRepository;

        public RoleStorage(DataContext context, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Add(string nameRole)
        {
            var result = await _roleRepository.Create(nameRole);
            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
                return OperationResult.Success;
            }
            else
            {
                return OperationResult.UnknounError;
            }
        }

        public async Task<ApplicationUser> Update(Guid userId, List<string> roles)
        {
            var user = await _roleRepository.Update(userId, roles);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(Guid roleId)
        {
            await _roleRepository.Delete(roleId);
            await _context.SaveChangesAsync();
        }
    }
}
