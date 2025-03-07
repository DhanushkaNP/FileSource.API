using Microsoft.AspNetCore.Http;

namespace CareerMate.EndPoints.Handlers
{
    public class ForbiddenResponse : BaseResponse
    {
        public ForbiddenResponse()
            : base(StatusCodes.Status403Forbidden)
        {
        }
    }
}
