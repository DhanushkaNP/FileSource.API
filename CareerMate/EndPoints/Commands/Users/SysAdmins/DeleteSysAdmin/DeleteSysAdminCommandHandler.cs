using CareerMate.EndPoints.Handlers;
using CareerMate.Infrastructure.Persistence.Repositories.SysAdmins;
using FileSource.EndPoints.Handlers;
using FileSource.Models.Entities.SysAdmins;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CareerMate.EndPoints.Commands.Users.SysAdmins.DeleteSysAdmin
{
    public class DeleteSysAdminCommandHandler : IRequestHandler<DeleteSysAdminCommand, BaseResponse>
    {
        private readonly ISysAdminRepository _sysAdminRepository;

        public DeleteSysAdminCommandHandler(ISysAdminRepository sysAdminRepository)
        {
            _sysAdminRepository = sysAdminRepository;
        }

        public async Task<BaseResponse> Handle(DeleteSysAdminCommand command, CancellationToken cancellationToken)
        {
            SysAdmin sysAdmin = await _sysAdminRepository.GetByIdAsync(command.Id, cancellationToken);

            if (sysAdmin == null || sysAdmin.IsDeleted)
            {
                return new NotFoundResponse<SysAdmin>();
            }

            sysAdmin.Delete();

            _sysAdminRepository.Update(sysAdmin);

            await _sysAdminRepository.SaveChangesAsync(cancellationToken);

            return new SuccessResponse();
        }
    }
}
