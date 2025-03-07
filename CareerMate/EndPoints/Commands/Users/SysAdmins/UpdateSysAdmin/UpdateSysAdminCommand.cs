using CareerMate.EndPoints.Handlers;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace CareerMate.EndPoints.Commands.Users.SysAdmins.UpdateSysAdmin
{
    public class UpdateSysAdminCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

        [EmailAddress]       
        public string Email { get; set;}


        public string Password { get; set;}

        [Required]
        public string FirstName { get; set;}

        [Required]
        public string LastName { get; set; }
    }
}
