using Microsoft.AspNetCore.Http;
using System;

namespace CareerMate.EndPoints.Handlers
{
    public class BadRequestResponse : BaseResponse
    {
        public BadRequestResponse(string messages)
            : base(StatusCodes.Status400BadRequest)
        {
            Message = messages;
        }

        public BadRequestResponse(string message, object addtionalData)
            : base(StatusCodes.Status400BadRequest)
        {
            Message = message;
            AdditionalData = addtionalData;
        }

        public BadRequestResponse(Guid errorCode)
            : base(StatusCodes.Status400BadRequest)
        {
            ErrorCode = errorCode;
        }

        public BadRequestResponse(Guid errorCode, string message)
            : base(StatusCodes.Status400BadRequest)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public BadRequestResponse(Guid errorCode, string message, object addtionalData)
            : base(StatusCodes.Status400BadRequest)
        {
            ErrorCode = errorCode;
            Message = message;
            AdditionalData = addtionalData;
        }

        private BadRequestResponse()
            : base(StatusCodes.Status400BadRequest)
        {
        }

        public string Message { get; set; }

        public Guid ErrorCode { get; set; }

        public object AdditionalData { get; set; }
    }
}
