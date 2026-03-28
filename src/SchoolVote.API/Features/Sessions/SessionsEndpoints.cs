using SchoolVote.API.Features.Sessions.CreateSession;
using SchoolVote.API.Features.Sessions.GetAllSessions;

namespace SchoolVote.API.Features.Sessions
{
    public static class SessionsEndpoints
    {
        public static IEndpointRouteBuilder MapSessionsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("Sessions").WithTags("Sessions");
            group.MapCreateSessionEndpoint();
            group.MapGetAllSessionsEndpoint();
            return app;
        }
    }
}
