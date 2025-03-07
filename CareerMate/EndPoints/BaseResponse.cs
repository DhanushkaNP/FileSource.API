using Microsoft.AspNetCore.Http;
using System;

namespace CareerMate.EndPoints.Handlers
{
    public abstract class BaseResponse
    {
        protected BaseResponse(int statusCode)
        {
            if (statusCode != StatusCodes.Status200OK &&
                statusCode != StatusCodes.Status201Created &&
                statusCode != StatusCodes.Status202Accepted &&
                statusCode != StatusCodes.Status204NoContent &&
                statusCode != StatusCodes.Status400BadRequest &&
                statusCode != StatusCodes.Status401Unauthorized &&
                statusCode != StatusCodes.Status403Forbidden &&
                statusCode != StatusCodes.Status404NotFound &&
                statusCode != StatusCodes.Status423Locked &&
                statusCode != StatusCodes.Status500InternalServerError &&
                statusCode != 580)
            {
                throw new ArgumentException(nameof(statusCode), "Status code is not valid");
            }

            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
