using System;

namespace SchoolVote.API.Features.Register.RegisterVoter;

public readonly record struct RegisterVoterResponse(Guid Id, string AuthKey, string Name, int MaxFemaleVotes, int MaxMaleVotes, int Grade);
