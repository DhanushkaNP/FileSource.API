using System.Net;
using System.Text.Json.Serialization;

namespace FileSource.Abstractions.Exceptions
{
    public class RequestException : CustomException
    {
        public RequestException()
        {
        }

        public RequestException(HttpStatusCode responseCode, string message)
            : this(responseCode, message, null)
        {
        }

        [JsonConstructor]
        public RequestException(HttpStatusCode httpStatusCode, string message, object responseObject)
            : base(message)
        {
            ResponseCode = httpStatusCode;
            ResponseObject = responseObject;
        }

        public object ResponseObject { get; }

        public HttpStatusCode ResponseCode { get; }
    }
}
