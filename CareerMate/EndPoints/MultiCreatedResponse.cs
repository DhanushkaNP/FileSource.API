using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;

namespace CareerMate.EndPoints.Handlers
{
    public class MultiCreatedResponse : BaseResponse
    {
        public MultiCreatedResponse(List<Guid> createdIds)
            : base(StatusCodes.Status201Created)
        {
            Ids = createdIds;
        }

        public List<Guid> Ids { get; private set; }
    }
}
