using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tests.Models
{
    public class ContextClass: IdentityDbContext<User>
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<Result> Results { get; set; }

        public ContextClass(DbContextOptions<ContextClass> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
