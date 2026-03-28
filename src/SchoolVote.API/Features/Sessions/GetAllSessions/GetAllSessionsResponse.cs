using SchoolVote.API.Features.Sessions.CreateSession;

namespace SchoolVote.API.Features.Sessions.GetAllSessions
{
    public readonly record struct GetAllSessionsResponse(List<CreateSessionResponse> Sessions);
}
