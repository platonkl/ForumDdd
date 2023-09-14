using ForumDdd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDdd.Data
{
    public class ForumDddDbContext : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;

        public ForumDddDbContext(DbContextOptions<ForumDddDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }


    }

}
