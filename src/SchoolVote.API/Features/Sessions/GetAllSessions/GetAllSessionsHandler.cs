using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Common.Abstractions;
using SchoolVote.API.Features.Sessions.CreateSession;
using SchoolVote.API.Infrastructure.Persistence;

namespace SchoolVote.API.Features.Sessions.GetAllSessions
{
    public class GetAllSessionsHandler(ApplicationDbContext context, ICurrentUserService currentUserService) : IRequestHandler<GetAllSessionsQuery, GetAllSessionsResponse>
    {
        public async Task<GetAllSessionsResponse> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
        {
            var userId = currentUserService.UserId;
            var user = await context.Administrators.Include(y => y.votingSessions).FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            if (user == null) throw new Exception("User not found");
            var allSessions = new List<CreateSessionResponse>();
            foreach(var session in user.votingSessions)
            {
                var createSession = new CreateSessionResponse
                {
                    SessionId = session.Id,
                    SessionName = session.VotingSessionName
                };
                allSessions.Add(createSession);
            }
            var response = new GetAllSessionsResponse(allSessions);
            return response;
        }
    }
}
