using System;
using MediatR;

namespace SchoolVote.API.Features.Register.RegisterVoter;

public readonly record struct RegisterVoterCommand(Guid SessionId, string Name, int Grade, int MaxFemaleVotes, int MaxMaleVotes) : IRequest<RegisterVoterResponse>;
