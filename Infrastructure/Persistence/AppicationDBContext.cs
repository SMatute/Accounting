
using Accounting.Domain.Configuration;
using Accounting.Domain.Entity;
using Accounting.Domain.Master;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
       
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }   


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsersRoles>()
                .HasKey(p =>  new { p.UserId, p.RoleId });
        }
         

    }
}
