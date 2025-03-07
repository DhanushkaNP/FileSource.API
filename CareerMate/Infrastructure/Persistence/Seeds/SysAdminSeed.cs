using Autofac.Core;
using CareerMate.Infrastructure.Persistence.Repositories.SysAdmins;
using FileSource.Models;
using FileSource.Models.Entities.ApplicationUsers;
using FileSource.Models.Entities.SysAdmins;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileSource.Infrastructure.Persistence.Seeds
{
    public class SysAdminSeed
    {
        private readonly IServiceProvider _serviceProvider;

        public SysAdminSeed(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }

        public async Task SeedUser()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var userManagerService = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                if (!await dbContext.SysAdmin.AnyAsync())
                {
                    ApplicationUser newUser = new ApplicationUser()
                    {
                        Email = "sysadmin@fileSource.com",
                        UserName = "sysadmin@fileSource.com",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        FirstName = "First",
                        LastName = "User",
                    };

                    var createdUserResult = await userManagerService.CreateAsync(newUser, "Test@123");

                    if (!createdUserResult.Succeeded)
                    {
                        throw new Exception(createdUserResult.Errors.FirstOrDefault().Description);
                    }

                    SysAdmin sysAdmin = new SysAdmin(newUser.Id);

                    dbContext.SysAdmin.Add(sysAdmin);

                    await dbContext.SaveChangesAsync();

                    await userManagerService.AddToRoleAsync(newUser, Roles.SysAdmin);
                }        
            }
        }
    }
}
