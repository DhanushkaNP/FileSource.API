using CareerMate.EndPoints.Handlers;
using CareerMate.Infrastructure.Persistence.Repositories.SysAdmins;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CareerMate.EndPoints.Queries.Users.SysAdmins.SysAdminUsersList
{
    public class GetSysAdminUsersListQueryHandler : IRequestHandler<GetSysAdminUsersListQuery, BaseResponse>
    {
        private readonly ISysAdminRepository _sysAdminRepository;

        public GetSysAdminUsersListQueryHandler(ISysAdminRepository sysAdminRepository)
        {
            _sysAdminRepository = sysAdminRepository;
        }

        public async Task<BaseResponse> Handle(GetSysAdminUsersListQuery query, CancellationToken cancellationToken)
        {
            PagedResponse<GetSysAdminUsersListQueryItem>  result = await _sysAdminRepository.GetSysAdminList(query, cancellationToken);
            return result;
        }
    }
}
