using MediatR;

namespace SchoolVote.API.Features.Sessions.GetAllSessions
{
    public readonly record struct GetAllSessionsQuery() : IRequest<GetAllSessionsResponse>;
}
