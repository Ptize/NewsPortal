using Microsoft.Extensions.Logging;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NewsPortal.Logging.LoggerExtensions.Builders.RoleBuilderLogger;

namespace NewsPortal.Domain.Builder
{
    public class RoleBuilder
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleStorage _roleStorage;
        private readonly ILogger _logger; 

        public RoleBuilder(IRoleRepository roleRepository, IRoleStorage roleStorage, ILogger<RoleBuilder> logger)
        {
            _roleRepository = roleRepository;
            _roleStorage = roleStorage;
            _logger = logger;
        }

        public async Task<ChangeRoleVM> Get(Guid userid)
        {
            _logger.GetRequestReceived(userid);
            return await _roleRepository.Get(userid);
        }
        public async Task<MyRoleVM> GetMyRole(string login)
        {
            _logger.GetMyRoleRequestReceived(login);
            return await _roleRepository.GetMyRole(login);
        }

        public async Task<OperationResult> Add(string nameRole)
        {
            _logger.AddRequestReceived(nameRole);
            var result = await _roleStorage.Add(nameRole);
            return result;
        }

        public async Task<OperationResult> Update(Guid userId, List<string> roles)
        {
            _logger.PutRequestReceived(userId, roles);
            await _roleStorage.Update(userId, roles);
            var result = OperationResult.Success;
            _logger.PutRequestReturns(result);
            return result;
        }
    }
}
