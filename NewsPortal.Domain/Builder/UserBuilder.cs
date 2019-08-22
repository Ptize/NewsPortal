using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.Enums;
using NewsPortal.Models.VeiwModels;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Builder
{
    public class UserBuilder
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserStorage _userStorage;

        public UserBuilder(IUserRepository userRepository, IUserStorage userStorage)
        {
            _userRepository = userRepository;
            _userStorage = userStorage;
        }

        public async Task<OperationResult> Add(RegisterVM registerVM)
        {
            await _userStorage.Add(registerVM);
            return OperationResult.Success;
        }

        public async Task<ApplicationUser> Get(Guid newsid)
        {
            return await _userRepository.Get(newsid);
        }

        public async Task<OperationResult> Update(ApplicationUserVM applicationUserVM)
        {
            await _userStorage.Update(applicationUserVM);
            return OperationResult.Success;
        }
    }
}
