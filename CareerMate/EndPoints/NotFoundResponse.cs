using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace CareerMate.EndPoints.Handlers
{
    public class NotFoundResponse : BaseResponse
    {
        public NotFoundResponse(string message)
            : base(StatusCodes.Status404NotFound)
        {
            Message = message;
        }

        public NotFoundResponse(Guid errorCode)
            : base(StatusCodes.Status404NotFound)
        {
            ErrorCode = errorCode;
        }

        public NotFoundResponse(Guid errorCode, string message)
            : this(message)
        {
            ErrorCode = errorCode;
        }

        public NotFoundResponse()
            : base(StatusCodes.Status404NotFound)
        {
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public Guid ErrorCode { get; set; }
    }

    public class NotFoundResponse<T> : BaseResponse
    where T : class
    {
        public NotFoundResponse()
            : base(StatusCodes.Status404NotFound)
        {
            Message = $"{typeof(T).Name} not found";
        }

        public NotFoundResponse(Guid errorCode)
            : this()
        {
            ErrorCode = errorCode;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public Guid ErrorCode { get; set; }
    }
}
