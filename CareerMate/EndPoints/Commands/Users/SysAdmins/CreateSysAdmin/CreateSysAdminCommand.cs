using CareerMate.EndPoints.Handlers;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CareerMate.EndPoints.Commands.Users.SysAdmins.CreateSysAdmin
{
    public class CreateSysAdminCommand : IRequest<BaseResponse>
    {
        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
