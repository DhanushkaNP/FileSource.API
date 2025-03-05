using Microsoft.AspNetCore.Identity;
using System;

namespace FileSource.Models.Entities.ApplicationUsers
{
    public class ApplicationUserRoles : IdentityRole<Guid>
    {
        public ApplicationUserRoles()
        {
        }


        public ApplicationUserRoles(string roleName)
            : base(roleName)
        {
        }
    }
}
