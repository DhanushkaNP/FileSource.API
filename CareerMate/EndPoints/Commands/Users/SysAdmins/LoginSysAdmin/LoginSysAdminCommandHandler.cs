using CareerMate.EndPoints.Commands.Users.SysAdmins.LoginSysAdmin;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using CareerMate.Infrastructure.Persistence.Repositories.SysAdmins;
using FileSource.Abstractions.Services;
using FileSource.Services.UserServices;
using FileSource.Models.Entities.SysAdmins;
using FileSource.Models;

namespace CareerMate.EndPoints.Handlers.SysAdmins.Login
{
    public class LoginSysAdminCommandHandler : IRequestHandler<LoginSysAdminCommand, BaseResponse>
    {
        private readonly IUserService _userService;
        private readonly ISysAdminRepository _sysAdminRepository;

        public LoginSysAdminCommandHandler(
            IUserService userService, ISysAdminRepository sysAdminRepository)
        {
            _userService = userService;
            _sysAdminRepository = sysAdminRepository;
        }

        public async Task<BaseResponse> Handle(LoginSysAdminCommand command, CancellationToken cancellationToken)
        {
            LoginUserDetailModel userDetails = await _userService.Login(command.Email, command.Password, new List<string>() { Roles.SysAdmin } , cancellationToken);

            SysAdmin sysAdmin = await _sysAdminRepository.GetSysAdminByApplicationUserId(userDetails.UserId, cancellationToken);

            return new LoginSysAdminCommandResponse()
            {
                Token = userDetails.Token,
                UserId = sysAdmin.Id,
            };
        }
    }
}
