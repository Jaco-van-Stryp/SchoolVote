using System;
using MediatR;

namespace SchoolVote.API.Features.Register.RegisterAdministrator;

public static class RegisterAdministratorEndpoint
{
    public static IEndpointRouteBuilder MapRegisterAdministratorEnpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("RegisterAdministrator", async (RegisterAdministratorCommand command, ISender sender) =>
        {
            var response = await sender.Send(command);
            return TypedResults.Ok(response);
        }).WithName("RegisterAdministrator");
        return app;
    }
}
