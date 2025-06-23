// Middleware/GlobalExceptionMiddleware.cs
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using API.Exceptions;

namespace API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro não tratado.");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            object responseObj;

            switch (exception)
            {
                case NotFoundException notFoundEx:
                    status = HttpStatusCode.NotFound;
                    responseObj = new { message = notFoundEx.Message };
                    break;

                case ValidationException validationEx:
                    status = HttpStatusCode.BadRequest;
                    responseObj = new { message = validationEx.Message, errors = validationEx.Errors };
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    responseObj = new { message = "Erro interno do servidor." };
                    break;
            }

            var payload = JsonSerializer.Serialize(responseObj);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(payload);
        }
    }
}
