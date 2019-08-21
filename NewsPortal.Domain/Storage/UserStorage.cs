using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Domain.Storage
{
    public class UserStorage : IUserStorage
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserStorage(DataContext context, IUserRepository userRepository, IMapper mapper)
        {
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Add(ApplicationUserVM authVm)
        {
            var user = new ApplicationUser()
            {
                UserName = authVm.UserName,
                Email = authVm.Email,
                ApiKey = authVm.Sign
            };
            await _userRepository.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid userId)
        {
            await _userRepository.Delete(userId);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> Get(Guid id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<ApplicationUser> Get(string email)
        {
            return await _userRepository.Get(email);
        }

        public async Task<ApplicationUser> Update(ApplicationUserVM authVm)
        {
            var user = _mapper.Map(authVm, await _context.Users.SingleAsync(n => n.Id == authVm.Id));
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateApiKey(ApplicationUser user, string apiKey)
        {
            user.ApiKey = apiKey;
            await _context.SaveChangesAsync();
        }
    }
}
