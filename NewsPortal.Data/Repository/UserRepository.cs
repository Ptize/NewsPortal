using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Repository
{
    public class UserRepository :IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);
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
