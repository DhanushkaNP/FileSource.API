using Microsoft.AspNetCore.Http;
using System;

namespace CareerMate.EndPoints.Handlers
{
    public class CreatedResponse : BaseResponse
    {
        public CreatedResponse()
           : base(StatusCodes.Status201Created)
        {
            Id = Guid.Empty;
        }

        public CreatedResponse(Guid createdId)
            : base(StatusCodes.Status201Created)
        {
            Id = createdId;
        }

        public Guid Id { get; private set; }
    }
}
