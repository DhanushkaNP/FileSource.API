using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CareerMate.EndPoints.Handlers
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
            : base(StatusCodes.Status200OK)
        {
        }

        public SuccessResponse(string message)
            : base(StatusCodes.Status200OK)
        {
            Message = message;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
