using Microsoft.AspNetCore.Http;

namespace FileSource.EndPoints.Handlers
{
    public class ForbiddenResponse : BaseResponse
    {
        public ForbiddenResponse()
            : base(StatusCodes.Status403Forbidden)
        {
        }
    }
}
