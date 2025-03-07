using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CareerMate.EndPoints.Handlers
{
    public class PagedResponse<T> : BaseResponse
    {
        public PagedResponse() : base(StatusCodes.Status200OK)
        {
        }

        public IEnumerable<T> Items { get; set; }

        public PagedResponseMetaData Meta { get; set; }
    }
}
