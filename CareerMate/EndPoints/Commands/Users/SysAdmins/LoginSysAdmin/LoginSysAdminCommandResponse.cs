using CareerMate.EndPoints.Handlers;
using Microsoft.AspNetCore.Http;
using System;

namespace CareerMate.EndPoints.Commands.Users.SysAdmins.LoginSysAdmin
{
    public class LoginSysAdminCommandResponse : BaseResponse
    {
        public LoginSysAdminCommandResponse() : base(StatusCodes.Status201Created)
        {
        }

        public string Token { get; set; }

        public Guid UserId { get; set; }
    }
}
