using System.Net;
using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Internal Server Error",
                Title = "Internal Server Error",
                Detail = "An Internal server error occurred",
            };

            string problemJson = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(problemJson);
            context.Response.ContentType = "application/problem+json";
        }
    }
}