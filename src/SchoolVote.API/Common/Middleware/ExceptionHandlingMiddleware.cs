using System.Net;
using System.Text.Json;
using FluentValidation;
using SchoolVote.API.Common.Exceptions;

namespace SchoolVote.API.Common.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (ValidationException ex)
        {
            _logger.LogWarning("Validation error: {Errors}", ex.Errors);
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            await WriteJson(context, HttpStatusCode.BadRequest, new { errors });
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning("Not found: {Message}", ex.Message);
            await WriteJson(context, HttpStatusCode.NotFound, new { error = ex.Message });
        }
        catch (ConflictException ex)
        {
            _logger.LogWarning("Conflict: {Message}", ex.Message);
            await WriteJson(context, HttpStatusCode.Conflict, new { error = ex.Message });
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning("Unauthorized: {Message}", ex.Message);
            await WriteJson(context, HttpStatusCode.Unauthorized, new { error = "Unauthorized." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await WriteJson(context, HttpStatusCode.InternalServerError, new { error = "An unexpected error occurred." });
        }
    }

    private static Task WriteJson(HttpContext context, HttpStatusCode status, object body)
    {
        context.Response.StatusCode = (int)status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }
}
