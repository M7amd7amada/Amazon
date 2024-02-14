using System.Net;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Amazon.Infrastructure.Common.Middlewares;

public class GlobalExceptionHandlingMiddleware(
    ILogger<GlobalExceptionHandlingMiddleware> logger) : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}