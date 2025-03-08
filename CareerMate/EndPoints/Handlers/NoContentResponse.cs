using Microsoft.AspNetCore.Http;

namespace FileSource.EndPoints.Handlers
{
    public class NoContentResponse : BaseResponse
    {
        public NoContentResponse()
            : base(StatusCodes.Status204NoContent)
        {
        }
    }
}
