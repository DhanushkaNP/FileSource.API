using FileSource.Abstractions;
using FileSource.Models.Entities.ApplicationUsers;
using FileSource.Models.Entities.Customers;
using FileSource.Models.Entities.SysAdmins;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FileSource.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRoles, Guid>, IUnitOfWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SysAdmin> SysAdmin { get; set; }

        public DbSet<Customer> Customer { get; set; }
    }
}
