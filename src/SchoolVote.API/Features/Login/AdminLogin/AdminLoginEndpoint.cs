using System;
using MediatR;

namespace SchoolVote.API.Features.Login.AdminLogin;

public static class AdminLoginEndpoint
{
    public static IEndpointRouteBuilder MapAdminLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("AdminLogin", async (AdminLoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return TypedResults.Ok(result);
        }).WithName("AdminLogin");
        return app;
    }
}
