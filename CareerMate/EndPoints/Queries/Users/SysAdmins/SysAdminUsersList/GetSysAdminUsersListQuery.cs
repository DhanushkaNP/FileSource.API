using CareerMate.EndPoints.Handlers;
using FileSource.Abstractions.Models.Queries;
using MediatR;

namespace CareerMate.EndPoints.Queries.Users.SysAdmins.SysAdminUsersList
{
    public class GetSysAdminUsersListQuery : PagedQuery, IRequest<BaseResponse>
    {
    }
}
