namespace SchoolVote.API.Features.Sessions.CreateSession
{
    public readonly record struct CreateSessionResponse(string SessionName, Guid SessionId);
}
