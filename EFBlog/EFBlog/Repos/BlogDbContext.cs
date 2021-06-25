using EFBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog
{
    // tell db these are the models we want to track and to make requests
    public class BlogDbContext : DbContext
    {
        public DbSet<BlogPost> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BlogUser> Users { get; set; }

        //this constructor takes options (in Startup.cs) and passes to base DB context
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }
    }
}
