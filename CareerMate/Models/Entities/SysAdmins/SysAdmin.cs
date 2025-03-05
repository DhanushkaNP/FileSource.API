using FileSource.Models.Entities.ApplicationUsers;
using System;

namespace FileSource.Models.Entities.SysAdmins
{
    public class SysAdmin : Entity
    {
        public SysAdmin(Guid applicationUserId)
        {
            ApplicationUserId = applicationUserId;
        }

        public DateTime? DeletedAt { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public ApplicationUser ApplicationUser { get; private set; }

        public bool IsDeleted
        {
            get
            {
                return DeletedAt.HasValue;
            }
        }

        public void Delete()
        {
            DeletedAt = DateTime.UtcNow;
        }

        public SysAdmin SetFirstName(string firstName)
        {
           ApplicationUser.SetFirstName(firstName);
            return this;
        }

        public SysAdmin SetLastName(string lastName)
        {
            ApplicationUser.SetLastName(lastName);
            return this;
        }

        public SysAdmin SetEmail(string email)
        {
            ApplicationUser.SetEmail(email);
            return this;
        }
    }
}
