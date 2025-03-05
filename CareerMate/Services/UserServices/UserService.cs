using FileSource.Models.Entities.ApplicationUsers;
using FileSource.Abstractions;
using FileSource.Abstractions.Exceptions;
using FileSource.Abstractions.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FileSource.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationUserRoles> _roleManager;
        private readonly IAuthService _authService;

        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationUserRoles> roleManager,
            IAuthService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
        }

        public async Task<Guid> CreateUser(string email, string password, string role, string firstName, string lastName, CancellationToken cancellation)
        {
            var isExistingUser = await _userManager.FindByEmailAsync(email);

            if (isExistingUser != null)
            {
                throw new BadRequestException(ErrorCodes.ExistingUser, "Existing user");
            }

            ApplicationUser newUser = new ApplicationUser()
            {
                Email = email,
                UserName = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
            };

            var createdUserResult = await _userManager.CreateAsync(newUser, password);

            if (!createdUserResult.Succeeded)
            {
                throw new BadRequestException(createdUserResult.Errors.FirstOrDefault().Description);
            }

            await _userManager.AddToRoleAsync(newUser, role);

            return newUser.Id;
        }

        public async Task<LoginUserDetailModel> Login(string email, string password, List<string> rolesLookingFor, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new BadRequestException(ErrorCodes.LoggingUserDetailsIncorrect, "Wrong user details");
            }

            bool isCorrectPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!isCorrectPassword)
            {
                throw new BadRequestException(ErrorCodes.LoggingUserDetailsIncorrect, "Wrong user details");
            }

            IList<string> userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Count != 0 && !rolesLookingFor.All(role => userRoles.Contains(role)))
            {
                throw new BadRequestException(ErrorCodes.LoggingUserDetailsIncorrect, "Wrong user details");
            }

            string token = await _authService.GenerateNewJsonWebToken(user.Id.ToString(), user.Email, userRoles);

            return new LoginUserDetailModel(token, user.Id);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());

            await _userManager.DeleteAsync(user);
        }

        public async Task<ApplicationUser> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new NotFoundException<ApplicationUser>();
            }

            return user;
        }

        public async Task UpdatePassword(Guid id, string password, CancellationToken cancellationToken)
        {
            ApplicationUser applicationUser = await _userManager.FindByIdAsync(id.ToString());

            var token = await _userManager.GeneratePasswordResetTokenAsync(applicationUser);

            try
            {
                await _userManager.ResetPasswordAsync(applicationUser, token, password);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<UserContextModel> GetUserContext(ClaimsPrincipal user, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(user);

            IList<string>  roles = await _userManager.GetRolesAsync(currentUser);

            return new UserContextModel
            {
                Role = roles.FirstOrDefault(),
                Id = currentUser.Id
            };
        }

        public async Task UpdateEmail(Guid userId, string newEmail, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new NotFoundException<ApplicationUser>();
            }

            // Directly update the email and username without generating a token
            user.Email = newEmail;
            user.UserName = newEmail;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to update email");
            }
        }
    }
}
