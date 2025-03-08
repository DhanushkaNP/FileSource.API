using FileSource.Abstractions.Models.Queries;
using FileSource.EndPoints.Handlers;
using MediatR;

namespace CareerMate.EndPoints.Queries.Users.SysAdmins.SysAdminUsersList
{
    public class GetSysAdminUsersListQuery : PagedQuery, IRequest<BaseResponse>
    {
    }
}
