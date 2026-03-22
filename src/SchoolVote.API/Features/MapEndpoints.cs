using System;
using SchoolVote.API.Features.Login;
using SchoolVote.API.Features.Register;

namespace SchoolVote.API.Features;

public static class MapEndpoints
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api");
        group.MapLoginEndpoints();
        group.MapRegisterEndpoints();
        return app;
    }
}
