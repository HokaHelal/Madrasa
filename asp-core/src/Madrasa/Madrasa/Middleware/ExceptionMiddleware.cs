using Madrasa.Shared.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Madrasa.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException badEx)
            {
                _logger.LogDebug(badEx, badEx.Message);
                await HandleApiException(context, HttpStatusCode.NotFound, badEx.Message);
            }
            catch (BadRequestException badEx)
            {
                _logger.LogDebug(badEx, badEx.Message);
                await HandleApiException(context, HttpStatusCode.BadRequest, badEx.Message);              
            }
            catch (UnauthorizedAccessException unAuthEx)
            {
                _logger.LogDebug(unAuthEx, unAuthEx.Message);
                await HandleApiException(context, HttpStatusCode.Unauthorized, unAuthEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Server Error");
                    ;
                response = new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString());
                await HandleApiException(context, HttpStatusCode.InternalServerError, response);
            }
        }

        private async Task HandleApiException(HttpContext context, HttpStatusCode statusCode, object exMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var response = exMessage;
            var opts = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, opts);

            await context.Response.WriteAsync(json);
        }

    }
}
