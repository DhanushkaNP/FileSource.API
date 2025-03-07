using Microsoft.AspNetCore.Http;

namespace CareerMate.EndPoints.Handlers
{
    public class NoContentResponse : BaseResponse
    {
        public NoContentResponse()
            : base(StatusCodes.Status204NoContent)
        {
        }
    }
}
