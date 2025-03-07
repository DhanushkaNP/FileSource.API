using CareerMate.Infrastructure.Persistence.Repositories.SysAdmins;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using CareerMate.EndPoints.Commands.Users.SysAdmins.CreateSysAdmin;
using FileSource.Abstractions.Services;
using FileSource.Models;
using FileSource.Models.Entities.SysAdmins;
using FileSource.Abstractions.Exceptions;

namespace CareerMate.EndPoints.Handlers.SysAdmins.Create
{
    public class CreateSysAdminCommandHandler : IRequestHandler<CreateSysAdminCommand, BaseResponse>
    {
        private readonly IUserService _userService;
        private readonly ISysAdminRepository _sysAdminRepository;

        public CreateSysAdminCommandHandler(IUserService userService, ISysAdminRepository sysAdminRepository)
        {
            _userService = userService;
            _sysAdminRepository = sysAdminRepository;
        }

        public async Task<BaseResponse> Handle(CreateSysAdminCommand command, CancellationToken cancellationToken)
        {
            Guid userID = await _userService.CreateUser(
                command.Email,
                command.Password,
                Roles.SysAdmin,
                command.FirstName,
                command.LastName,
                cancellationToken);

            SysAdmin newSysAdmin = new SysAdmin(userID);

            _sysAdminRepository.Add(newSysAdmin);

            var result = await _sysAdminRepository.SaveChangesAsync(cancellationToken);

            if (result == 0)
            {
                await _userService.DeleteAsync(userID);
                throw new BadRequestException("Something went wrong when creating sysadmin");
            }

            return new CreateSysAdminCommandResponse()
            {
                Id = userID
            };
        }

    }
}
