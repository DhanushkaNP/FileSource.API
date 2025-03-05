using FileSource.Models.Entities.SysAdmins;
using Microsoft.AspNetCore.Identity;
using System;

namespace FileSource.Models.Entities.ApplicationUsers
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? ModifiedAt { get; private set; }

        public DateTime? DeletedAt { get; private set; }

        public SysAdmin SysAdmin { get; private set; }


        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
