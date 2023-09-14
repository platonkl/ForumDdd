using ForumDdd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDdd.Data
{
    public class ForumDddContext : DbContext
    {

        public ForumDddContext(DbContextOptions<ForumDddContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
    }

}
