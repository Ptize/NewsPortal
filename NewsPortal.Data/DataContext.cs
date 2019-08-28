using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Models.Data;

namespace NewsPortal.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<News> Newss { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasKey(c => new { c.NewsId, c.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
