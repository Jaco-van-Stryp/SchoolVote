using MediatR;

namespace SchoolVote.API.Features.Sessions.CreateSession
{
    public readonly record struct CreateSessionCommand(string VotingSessionName) : IRequest<CreateSessionResponse>;
}
