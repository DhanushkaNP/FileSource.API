using System;
using System.Text.Json.Serialization;

namespace FileSource.Abstractions.Exceptions
{
    public class LockedException : CustomException
    {
        [JsonConstructor]
        public LockedException(Guid objectId, Type objectType, TimeSpan timeout)
            : base("Locked")
        {
            ObjectId = objectId;
            ObjectType = objectType;
            Timeout = timeout;
        }

        public LockedException(Guid objectId, Type objectType)
            : base("Locked")
        {
            ObjectId = objectId;
            ObjectType = objectType;
            Timeout = null;

        }

        private LockedException()
        {
        }

        public Guid ObjectId { get; }

        public Type ObjectType { get; }

        public TimeSpan? Timeout { get; }
    }
}
