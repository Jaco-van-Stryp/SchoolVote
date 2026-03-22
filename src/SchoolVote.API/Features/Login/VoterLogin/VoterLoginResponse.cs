using System;

namespace SchoolVote.API.Features.Login.VoterLogin;

public readonly record struct VoterLoginResponse(string Jwt, int AuthorizedGrade, int MaleVotes, int FemaleVotes);
