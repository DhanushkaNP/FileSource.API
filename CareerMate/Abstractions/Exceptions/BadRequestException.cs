using System;
using System.Text.Json.Serialization;

namespace FileSource.Abstractions.Exceptions
{
    public class BadRequestException : CustomException
    {
        public BadRequestException()
            : base()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(Guid errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public BadRequestException(string message, object additionalData)
            : base(message)
        {
            AdditionalData = additionalData;
        }

        public BadRequestException(Guid errorCode, string message, object additionalData)
            : base(message)
        {
            ErrorCode = errorCode;
            AdditionalData = additionalData;
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BadRequestException(Guid errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        [JsonConstructor]
        private BadRequestException(Guid errorCode, string message, Exception innerException, object additionalData)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
            AdditionalData = additionalData;
        }

        public Guid ErrorCode { get; private set; }

        public object AdditionalData { get; private set; }
    }
}
