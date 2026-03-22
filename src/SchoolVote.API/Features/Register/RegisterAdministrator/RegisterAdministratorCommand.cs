using System;
using MediatR;

namespace SchoolVote.API.Features.Register.RegisterAdministrator;

public readonly record struct RegisterAdministratorCommand(string Username, string Password) : IRequest<RegisterAdministratorResponse>;
