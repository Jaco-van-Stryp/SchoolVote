using System;
using SchoolVote.API.Features.Login;

namespace SchoolVote.API.Features;

public static class MapEndpoints
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api");
        group.MapLoginEndpoints();
        return app;
    }
}
