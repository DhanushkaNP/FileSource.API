using FileSource.Models;
using FileSource.Abstractions.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace FileSource
{
    public static class RolePolicyConfigurations
    {
        public static IServiceCollection AddRolesPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.SysAdminOnly,
                    policy => policy.RequireRole(Roles.SysAdmin));
                //options.AddPolicy(Policies.CoordinatorOnly,
                //    policy => policy.RequireRole(Roles.Coordinator));
                //options.AddPolicy(Policies.StudentOnly,
                //    policy => policy.RequireRole(Roles.Student));
                //options.AddPolicy(Policies.CompaniesOnly,
                //    policy => policy.RequireRole(Roles.Company));
                //options.AddPolicy(Policies.SupervisorOnly,
                //    policy => policy.RequireRole(Roles.CompanySupervisor));

                //options.AddPolicy(Policies.CoordinatorLevel,
                //    policy => policy.RequireRole(Roles.SysAdmin ,Roles.Coordinator));
                //options.AddPolicy(Policies.CoordinatorAssistantLevel,
                //    policy => policy.RequireRole(Roles.SysAdmin, Roles.Coordinator, Roles.CoordinatorAssistant));
                
                //options.AddPolicy(Policies.AllUserRoles,
                //    policy => policy.RequireRole(Roles.SysAdmin, Roles.Coordinator, Roles.CoordinatorAssistant, Roles.Company, Roles.Student, Roles.CompanySupervisor));

                //options.AddPolicy(Policies.CompanyAndCoordinatorLevel,
                //    policy => policy.RequireRole(Roles.Coordinator, Roles.CoordinatorAssistant, Roles.Company));

                //options.AddPolicy(Policies.StudentAndCompanyLevel,
                //    policy => policy.RequireRole(Roles.Company, Roles.Student));
            });

            return services;
        }
    }
}
