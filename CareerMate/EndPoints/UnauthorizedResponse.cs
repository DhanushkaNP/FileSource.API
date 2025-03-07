using Microsoft.AspNetCore.Http;

namespace CareerMate.EndPoints.Handlers
{
    public class UnauthorizedResponse : BaseResponse
    {
        public UnauthorizedResponse(string message) : base(StatusCodes.Status401Unauthorized)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
