using Microsoft.EntityFrameworkCore;
using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Data
{
    public class DataContext : DbContext
    {
        public DbSet<News> Newss { get; set; } 

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
