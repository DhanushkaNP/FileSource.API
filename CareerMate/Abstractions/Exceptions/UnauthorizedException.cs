using System.Text.Json.Serialization;

namespace FileSource.Abstractions.Exceptions
{
    public class UnauthorizedException : CustomException
    {
        public UnauthorizedException()
            : base()
        {
        }

        [JsonConstructor]
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
