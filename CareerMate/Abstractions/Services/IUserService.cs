using FileSource.Models.Entities.ApplicationUsers;
using FileSource.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.Abstractions.Services
{
    public interface IUserService
    {
        Task<Guid> CreateUser(string email, string password, string role, string firstName, string lastName, CancellationToken cancellationToken);

        Task<LoginUserDetailModel> Login(string email, string password, List<string> rolesLookingFor, CancellationToken cancellationToken);

        Task DeleteAsync(Guid Id);

        Task<ApplicationUser> GetUserById(Guid id, CancellationToken cancellationToken);

        Task UpdatePassword(Guid id, string password, CancellationToken cancellationToken);

        Task<UserContextModel> GetUserContext(ClaimsPrincipal user, CancellationToken cancellationToken);

        Task UpdateEmail(Guid userId, string newEmail, CancellationToken cancellationToken);
    }
}
