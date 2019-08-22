using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserStorage(DataContext context, IUserRepository userRepository, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task Add(RegisterVM registerVM)
        {
            var user = new ApplicationUser()
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
            };
            
            await _userRepository.Add(user, registerVM.Password);
            //await _signInManager.SignInAsync(user, false);
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
            ApplicationUser user = null;// _mapper.Map(authVm, await _context.Users.SingleAsync(n => n.Id == authVm.Id));
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
