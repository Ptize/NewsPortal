using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<UsersListVM> GetAll(int count, int page)
        {
            var countEntity = await _userRepository.Count();

            var users = new UsersListVM
            {
                CountPage = countEntity % count == 0 ? countEntity / count : (countEntity / count) + 1,
                UsersList = await _userRepository.GetAll(count, page)
            };
            return users;
        }

        public async Task<OperationResult> Add(RegisterVM registerVM)
        {
            var user = new ApplicationUser()
            {
                Email = registerVM.Email,
                UserName = registerVM.Email,
            };

            var result = await _userRepository.Add(user, registerVM.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                await _context.SaveChangesAsync();
                return OperationResult.Success;
            }
            else
            {
                return OperationResult.InvalidPassword;
            }

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

        public async Task<ApplicationUser> Update(EditUserVM editUserVM)
        {
            var user = await _userRepository.Update(editUserVM);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<OperationResult> Login(LoginVM loginVM)
        {
            var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, false);

            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
                return OperationResult.Success;
            }
            else
            {
                return OperationResult.InvalidPassword;
            }
        }

        public async Task<OperationResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return OperationResult.Success;
        }

        public async Task<OperationResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var result = await _userRepository.UpdatePassword(changePasswordVM);
            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
                return OperationResult.Success;
            }
            else
            {
                return OperationResult.InvalidPassword;
            }
        }

        public async Task<OperationResult> ChangeForgotPassword(ChangeForgotPasswordVM changeForgotPasswordVM)
        {
            var result = await _userRepository.UpdateForgotPassword(changeForgotPasswordVM);
            if (result.Succeeded)
            {
                await _context.SaveChangesAsync();
                return OperationResult.Success;
            }
            else
            {
                return OperationResult.InvalidPassword;
            }
        }
    }
}
