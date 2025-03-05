using FileSource.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FileSource.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<GlobalExceptionHandlerMiddleware>>();

            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex, logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            HandleLogging(exception, logger);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetHttpStatusCode(exception);
            await context.Response.WriteAsync(GetResult(exception));
        }

        private void HandleLogging(Exception ex, ILogger logger)
        {
            if (ex is BadRequestException || 
                ex is ValidationException || 
                ex is LockedException || 
                ex is RequestException || 
                ex is UnauthorizedException || 
                ex is ForbiddenException || 
                ex is NotFoundException)
            {
                return;
            }

            logger.LogError(ex, nameof(ex));
        }

        private string GetResult(Exception exception)
        {
            if (exception is BadRequestException ex)
            {
                return JsonConvert.SerializeObject(new { ex.Message, ex.ErrorCode, ex.AdditionalData });
            }

            if (exception is RequestException ex2)
            {
                return JsonConvert.SerializeObject(new
                {
                    Message = ex2.Message,
                    Error = ex2.ResponseObject
                });
            }

            if (exception is LockedException ex3)
            {
                return JsonConvert.SerializeObject(new
                {
                    ex3.ObjectId,
                    ex3.ObjectType.Name,
                    ex3.Timeout
                });
            }

            if (exception is NotFoundException ex4)
            {
                return JsonConvert.SerializeObject(new { ex4.Message, ex4.ErrorCode });
            }

            return JsonConvert.SerializeObject(new { exception.Message });
        }

        public static int GetHttpStatusCode(Exception ex)
        {
            if (ex is BadRequestException || ex is ValidationException)
            {
                return 400;
            }

            if (ex is RequestException ex2)
            {
                return (int)ex2.ResponseCode;
            }

            if (ex is LockedException)
            {
                return 423;
            }

            if (ex is UnauthorizedException)
            {
                return 401;
            }

            if (ex is ForbiddenException)
            {
                return 403;
            }

            if (ex is NotFoundException || (ex.GetType().IsGenericType && ex.GetType().GetGenericTypeDefinition() == typeof(NotFoundException<>)))
            {
                return 404;
            }

            if (ex is TaskCanceledException || ex is OperationCanceledException)
            {
                return 499;
            }

            return 500;
        }
    }
}
