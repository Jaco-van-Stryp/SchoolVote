using SchoolVote.API.Common.Middleware;

namespace SchoolVote.API.Common.Extensions;

public static class ExceptionHandlingExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        return app;
    }
}
