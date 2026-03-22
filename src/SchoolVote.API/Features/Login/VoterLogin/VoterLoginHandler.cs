using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Common.Abstractions;
using SchoolVote.API.Common.Exceptions;
using SchoolVote.API.Infrastructure.Persistence;

namespace SchoolVote.API.Features.Login.VoterLogin;

public class VoterLoginHandler(ApplicationDbContext context, IJwtService jwtService) : IRequestHandler<VoterLoginCommand, VoterLoginResponse>
{
    public async Task<VoterLoginResponse> Handle(VoterLoginCommand request, CancellationToken cancellationToken)
    {
        var voter = await context.Voters.FirstOrDefaultAsync(x => x.Id == request.UserID);
        if (voter == null)
            throw new UserNotFoundException("Voter Not Found");
        if (voter.AuthKey.ToLower() != request.UserAuthKey.ToLower() || voter.AuthName != request.UserName || voter.Voted)
            throw new UnauthorizedAccessException();

        string[] roles = ["Voter"];
        var resJwt = jwtService.GenerateToken(voter.Id, roles);

        var response = new VoterLoginResponse(Jwt: resJwt, voter.AuthorizedGrade, voter.MaleVotes, voter.FemaleVotes);
        return response;
    }
}
