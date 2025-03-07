using CareerMate.EndPoints.Handlers;
using System;

namespace CareerMate.EndPoints.Queries.Users.SysAdmins
{
    public class GetSysAdminUsersListQueryItem : BaseResponse
    {
        public GetSysAdminUsersListQueryItem(string firstName, string lastName, string email, DateTime dateCreated, Guid id)
            : base(200)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateCreated = dateCreated;
            Id = id;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid Id { get; set; }
    }
}
