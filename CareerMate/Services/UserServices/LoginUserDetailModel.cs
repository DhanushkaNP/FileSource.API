using System;

namespace FileSource.Services.UserServices
{
    public class LoginUserDetailModel
    {
        public LoginUserDetailModel(string token, Guid userId)
        {
            Token = token;
            UserId = userId;
        }

        public string Token { get; set; }

        public Guid UserId { get; set; }
    }
}
