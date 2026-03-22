using System;
using System.CodeDom.Compiler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Common.Entities;
using SchoolVote.API.Common.Exceptions;
using SchoolVote.API.Infrastructure.Persistence;

namespace SchoolVote.API.Features.Register.RegisterVoter;

public class RegisterVoterHandler(ApplicationDbContext context) : IRequestHandler<RegisterVoterCommand, RegisterVoterResponse> // Todo - concider sending and email in the future.
{
    public async Task<RegisterVoterResponse> Handle(RegisterVoterCommand request, CancellationToken cancellationToken)
    {
        var sessionVoters = await context.VotingSessions.FirstOrDefaultAsync(x => x.Id == request.SessionId);
        if (sessionVoters == null) throw new UserNotFoundException("Session not found");
        var voterAuthKey = GenerateVoterAuthKey(7);
        var newVoter = new Voters
        {
            AuthKey = voterAuthKey,
            AuthName = request.Name,
            AuthorizedGrade = request.Grade,
            FemaleVotes = request.MaxFemaleVotes,
            MaleVotes = request.MaxMaleVotes,
            Voted = false,
        };
        sessionVoters.Voters.Add(newVoter);
        await context.SaveChangesAsync();
        var res = new RegisterVoterResponse(Id: newVoter.Id, AuthKey: voterAuthKey, request.Name, request.MaxFemaleVotes, request.MaxMaleVotes, request.Grade);
        return res;
    }

    private string GenerateVoterAuthKey(int length)
    {
        char[] letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        Random random = new Random();
        string key = "";
        for (int i = 0; i >= length; i++)
        {
            var randomNumber = random.Next(0, 25);
            key += letters[randomNumber];
        }
        return key;
    }
}
