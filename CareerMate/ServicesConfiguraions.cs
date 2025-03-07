using FileSource.Abstractions.Services;
using FileSource.Infrastructure.Persistence.Seeds;
using FileSource.Infrastructure.Persistence;
using FileSource.Models.Entities.ApplicationUsers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using FileSource.Services.AuthServices;
using FileSource.Services.UserServices;
using Microsoft.Extensions.Logging;
using Quartz;

namespace FileSource
{
    public static class ServicesConfigurations
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DB
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"));

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });

            // Add Identity
            services
                .AddIdentity<ApplicationUser, ApplicationUserRoles>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Config Identity
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
            });

            // Add Authentication and JwtBearer
            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = configuration["JWTAuthenticatom:ValidIssuer"],
                        ValidAudience = configuration["JWTAuthenticatom:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTAuthenticatom:Secret"]))
                    };
                });

            // Add Mediator 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


            // Add Automapper
            services.AddAutoMapper(
                options =>
                {
                    options.AllowNullCollections = true;
                },
                Assembly.GetAssembly(typeof(Program)));

            services.AddLogging(logging => logging.AddConsole());

            return services;
        }

        public static IServiceCollection RegisterSystemServices(this IServiceCollection services)
        {
            services.AddScoped<IdentityRoleSeed>();
            services.AddScoped<SysAdminSeed>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection RegisterBackgroundJobs(this IServiceCollection services)
        {
            // Add Quartz.NET services
            services.AddQuartz(q =>
            {
                // Create a job : To Do
                //var jobKey = new JobKey(nameof(UnlockDailyDiariesJob));
                //q.AddJob<UnlockDailyDiariesJob>(opts => opts.WithIdentity(jobKey));

                //// Create a trigger to run the job daily at 1 AM
                //q.AddTrigger(opts => opts
                //    .ForJob(jobKey)
                //    .WithIdentity("UnlockDailyDiariesJob-trigger")
                //    .WithCronSchedule("0 0 1 * * ?"));
            });

            // Add the Quartz.NET hosted service
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            return services;
        }
    }
}
