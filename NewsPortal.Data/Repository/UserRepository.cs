using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NewsPortal.Data.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HttpContext _httpContext;

        public UserRepository(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<int> Count()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<List<BriefUserVM>> GetAll(int countEntity, int page)
        {
            var listBriefUserVM = _context.Users
                .Skip(countEntity * (page - 1))
                .Take(countEntity);

            var resListBriefUserVM = (from i in listBriefUserVM
                                      select new BriefUserVM
                                      {
                                          Id = i.Id,
                                          Email = i.Email,
                                      }).ToListAsync();


            return await resListBriefUserVM;
        }

        public async Task<IdentityResult> Add(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<ApplicationUser> Update(EditUserVM editUserVM)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(editUserVM.Id);
            if (user != null)
            {
                user.Email = editUserVM.Email;
                user.UserName = editUserVM.Email;
                var result = await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task Delete(Guid userId)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == userId.ToString());
            _context.Users.Remove(user);
        }

        public async Task<ApplicationUser> Get(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<ApplicationUser> Get(Guid id)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == id.ToString());
            return user;
        }

        public async Task<IdentityResult> UpdatePassword(ChangePasswordVM changePasswordVM)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(changePasswordVM.Id);
            IdentityResult result = IdentityResult.Failed();
            if (user != null)
            {
                result = await _userManager.ChangePasswordAsync(user, changePasswordVM.OldPassword, changePasswordVM.NewPassword);
                await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IdentityResult> UpdateForgotPassword(ChangeForgotPasswordVM changeForgotPasswordVM)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(changeForgotPasswordVM.Id);
            IdentityResult result = IdentityResult.Failed();
            if (user != null)
            {
                var _passwordValidator = _httpContext.RequestServices.GetService(typeof(IPasswordValidator<ApplicationUser>)) as IPasswordValidator<ApplicationUser>;
                var _passwordHasher = _httpContext.RequestServices.GetService(typeof(IPasswordHasher<ApplicationUser>)) as IPasswordHasher<ApplicationUser>;

                result = await _passwordValidator.ValidateAsync(_userManager, user, changeForgotPasswordVM.NewPassword);
                if (result.Succeeded)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, changeForgotPasswordVM.NewPassword);
                    await _userManager.UpdateAsync(user);
                    await _context.SaveChangesAsync();
                }
            }
            return result;
        }
    }
}
