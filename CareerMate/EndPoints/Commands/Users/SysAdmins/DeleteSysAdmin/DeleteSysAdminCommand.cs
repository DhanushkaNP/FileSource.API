using CareerMate.EndPoints.Handlers;
using MediatR;
using System;

namespace CareerMate.EndPoints.Commands.Users.SysAdmins.DeleteSysAdmin
{
    public class DeleteSysAdminCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
