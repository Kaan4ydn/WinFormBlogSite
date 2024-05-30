using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormBlogSite.Entities;

namespace WinFormBlogSite.Context
{
    public class BlogSiteContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-SO3FKM0;database=BlogSiteDb;trusted_connection=true;trustservercertificate=true");
        }
    }
}
