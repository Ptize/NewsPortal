using Microsoft.AspNetCore.Identity;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Models.Data;
using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(DataContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ChangeRoleVM> Get(Guid id)
        {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            ChangeRoleVM model = new ChangeRoleVM();
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                model = new ChangeRoleVM
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
            }
            return model;
        }

        public async Task<MyRoleVM> GetMyRole(string login)
        {
            // получаем пользователя
            ApplicationUser user = await _userManager.FindByEmailAsync(login);
            MyRoleVM model = new MyRoleVM();
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                model = new MyRoleVM
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles
                };
            }
            return model;
        }

        public async Task<IdentityResult> Create(string nameRole)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(nameRole));
            return result;
        }

        public async Task<ApplicationUser> Update(Guid userId, List<string> roles)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task Delete(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            await _roleManager.DeleteAsync(role);
        }
    }
}
