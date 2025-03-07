using System;

namespace CareerMate.EndPoints.Handlers
{
    public class ExistsResponse : BadRequestResponse
    {
        public ExistsResponse(string name, string messages)
            : base(messages)
        {
            Name = name;
        }

        public ExistsResponse(string name, Guid errorCode)
            : base(errorCode)
        {
            Name = name;
        }

        public ExistsResponse(string name, Guid errorCode, string message)
            : base(errorCode, message)
        {
            Name = name;
        }

        public ExistsResponse(string name, Guid errorCode, string message, object addtionalData)
            : base(errorCode, message, addtionalData)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
