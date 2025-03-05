using FileSource.Models.Entities.ApplicationUsers;
using System;

namespace FileSource.Models.Entities.Customers
{
    public class Customer : Entity
    {
        public Customer(Guid applicationUserId)
        {
            ApplicationUserId = applicationUserId;
        }

        public DateTime? DeletedAt { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public ApplicationUser ApplicationUser { get; private set; }

        public void Delete()
        {
            DeletedAt = DateTime.UtcNow;
        }
        public bool IsDeleted
        {
            get
            {
                return DeletedAt.HasValue;
            }
        }

        public Customer SetFirstName(string firstName)
        {
            ApplicationUser.SetFirstName(firstName);
            return this;
        }

        public Customer SetLastName(string lastName)
        {
            ApplicationUser.SetLastName(lastName);
            return this;
        }

        public Customer SetEmail(string email)
        {
            ApplicationUser.SetEmail(email);
            return this;
        }
    }
}
