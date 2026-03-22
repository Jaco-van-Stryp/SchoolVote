using System;
using MediatR;

namespace SchoolVote.API.Features.Register.RegisterVoter;

public static class RegisterVoterEndpoint
{
    public static IEndpointRouteBuilder MapRegisterVoterEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("RegisterVoter", async (RegisterVoterCommand command, ISender sender) =>
        {
            var response = await sender.Send(command);
            return TypedResults.Ok(response);
        })
        .WithName("RegisterVoter")
        .RequireAuthorization("Administrator");
        return app;
    }
}
