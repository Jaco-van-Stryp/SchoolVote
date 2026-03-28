using MediatR;

namespace SchoolVote.API.Features.Sessions.CreateSession
{
    public static class CreateSessionEndpoint
    {
        public static IEndpointRouteBuilder MapCreateSessionEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("CreateSession", async (CreateSessionCommand command, ISender sender) => {
                var response = await sender.Send(command);
                return TypedResults.Ok(response);
            }).WithName("CreateSession").RequireAuthorization("Administrator");
            return app;
        }
    }
}
