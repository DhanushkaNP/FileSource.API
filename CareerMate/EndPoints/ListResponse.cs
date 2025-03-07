using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CareerMate.EndPoints.Handlers
{
    public class ListResponse<T> : BaseResponse
        where T : new()
    {
        public ListResponse()
            : base(StatusCodes.Status200OK)
        {
        }

        public IEnumerable<T> Items { get; set; }
    }
}
