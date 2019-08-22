using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Models.Data;
using System;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Add(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
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
    }
}
