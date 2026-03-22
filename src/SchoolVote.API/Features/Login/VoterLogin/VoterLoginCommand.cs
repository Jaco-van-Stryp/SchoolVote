using System;
using MediatR;

namespace SchoolVote.API.Features.Login.VoterLogin;

public readonly record struct VoterLoginCommand(Guid UserID, string UserName, string UserAuthKey) : IRequest<VoterLoginResponse>;
