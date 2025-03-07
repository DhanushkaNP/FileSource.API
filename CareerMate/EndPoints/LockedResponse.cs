using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json.Serialization;

namespace CareerMate.EndPoints.Handlers
{
    public class LockedResponse : BaseResponse
    {
        [JsonConstructor]
        public LockedResponse(Guid objectId, string objectType, TimeSpan? timeout)
            : base(StatusCodes.Status423Locked)
        {
            ObjectId = objectId;
            ObjectType = objectType;
            Timeout = timeout;
        }

        public LockedResponse(Guid objectId, Type objectType, TimeSpan timeout)
            : this(objectId, objectType.FullName, timeout)
        {
        }

        public LockedResponse(Guid objectId, string objectType)
            : base(StatusCodes.Status423Locked)
        {
            ObjectId = objectId;
            ObjectType = objectType;
            Timeout = null;
        }

        public LockedResponse(Guid objectId, Type objectType)
            : this(objectId, objectType.FullName)
        {
        }

        private LockedResponse()
            : base(StatusCodes.Status423Locked)
        {
        }

        public Guid ObjectId { get; }

        public string ObjectType { get; }

        public TimeSpan? Timeout { get; }
    }
}
