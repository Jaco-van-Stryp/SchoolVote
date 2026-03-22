using System;
using MediatR;

namespace SchoolVote.API.Features.Login.AdminLogin;

public readonly record struct AdminLoginCommand(string Username, string Password) : IRequest<AdminLoginResponse>;
