using System;
using SchoolVote.API.Features.Login;
using SchoolVote.API.Features.Register;
using SchoolVote.API.Features.Sessions;

namespace SchoolVote.API.Features;

public static class MapEndpoints
{
    public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api");
        group.MapLoginEndpoints();
        group.MapRegisterEndpoints();
        group.MapSessionsEndpoints();
        return app;
    }
}
