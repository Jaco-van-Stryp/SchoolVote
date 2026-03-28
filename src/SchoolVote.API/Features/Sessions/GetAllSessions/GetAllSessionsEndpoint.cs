using MediatR;

namespace SchoolVote.API.Features.Sessions.GetAllSessions
{
    public static class GetAllSessionsEndpoint
    {
        public static IEndpointRouteBuilder MapGetAllSessionsEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("GetAllSessions", async (ISender sender) => {
                var response = await sender.Send(new GetAllSessionsQuery());
                return TypedResults.Ok(response);
            });
            return app;
        }
    }
}
