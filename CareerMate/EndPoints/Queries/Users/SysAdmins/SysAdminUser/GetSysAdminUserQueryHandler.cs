using CareerMate.EndPoints.Handlers;
using CareerMate.Infrastructure.Persistence.Repositories.SysAdmins;
using FileSource.EndPoints.Handlers;
using FileSource.Models.Entities.SysAdmins;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CareerMate.EndPoints.Queries.Users.SysAdmins.SysAdminUser
{
    public class GetSysAdminUserQueryHandler : IRequestHandler<GetSysAdminUserQuery, BaseResponse>
    {
        private readonly ISysAdminRepository _repository;

        public GetSysAdminUserQueryHandler(ISysAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(GetSysAdminUserQuery query, CancellationToken cancellationToken)
        {
            SysAdmin sysAdminUser = await _repository.GetByIdAsync(query.Id, cancellationToken);

            if (sysAdminUser == null)
            {
                return new NotFoundResponse<SysAdmin>();
            }

            return new GetSysAdminUsersListQueryItem(
                sysAdminUser.ApplicationUser.FirstName,
                sysAdminUser.ApplicationUser.LastName,
                sysAdminUser.ApplicationUser.Email,
                sysAdminUser.CreatedAt,
                sysAdminUser.Id);
        }
    }
}
