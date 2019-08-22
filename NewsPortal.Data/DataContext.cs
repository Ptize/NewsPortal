using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Models.Data;

namespace NewsPortal.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<News> Newss { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
