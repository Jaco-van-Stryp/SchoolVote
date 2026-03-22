using System;
using MediatR;

namespace SchoolVote.API.Features.Login.VoterLogin;

public static class VoterLoginEndpoint
{
    public static IEndpointRouteBuilder MapVoterLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("VoterLogin", async (VoterLoginCommand command, ISender sender) =>
        {
            var response = await sender.Send(command);
            return TypedResults.Ok(response);
        }).WithName("VoterLogin");
        return app;
    }
}
