using CareerMate.EndPoints.Handlers;
using MediatR;
using System;

namespace CareerMate.EndPoints.Queries.Users.SysAdmins.SysAdminUser
{
    public class GetSysAdminUserQuery : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
