using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Common.Abstractions;
using SchoolVote.API.Common.Entities;
using SchoolVote.API.Common.Exceptions;
using SchoolVote.API.Infrastructure.Persistence;

namespace SchoolVote.API.Features.Sessions.CreateSession
{
    public class CreateSessionHandler(ApplicationDbContext context, ICurrentUserService currentUserService) : IRequestHandler<CreateSessionCommand, CreateSessionResponse>
    {
        public async Task<CreateSessionResponse> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
           
            var userId = currentUserService.UserId;
            var currentUser = await context.Administrators.Include(y => y.votingSessions).FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            if (currentUser == null) throw new UnauthorizedAccessException("You are not authorized to access this.");
            var sessions = currentUser.votingSessions.FirstOrDefault(x => x.VotingSessionName.ToLower() == request.VotingSessionName.ToLower());
            if (sessions != null) throw new ConflictException("A voting session with that name already exists.");
            var Id = Guid.NewGuid();
            var newVotingSession = new VotingSessions
            {
                Id = Id,
                Administrator = currentUser,
                AdministratorId = currentUser.Id,
                VotingSessionName = request.VotingSessionName,
            };
            await context.AddAsync(newVotingSession);
            await context.SaveChangesAsync();
            var response = new CreateSessionResponse(request.VotingSessionName, Id);
            return response;
        }
    }
}
