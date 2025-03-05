using System;
using System.Text.Json.Serialization;

namespace FileSource.Abstractions.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }

        [JsonConstructor]
        public NotFoundException(Guid errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        public Guid ErrorCode { get; private set; }
    }

    public class NotFoundException<T> : CustomException
    {
        public NotFoundException()
            : base($"{typeof(T).Name} not found")
        {
        }
    }
}
