using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Common.Exceptions;
using SchoolVote.API.Common.Abstractions;
using SchoolVote.API.Infrastructure.Persistence;

namespace SchoolVote.API.Features.Login.AdminLogin;

public class AdminLoginHandler(ApplicationDbContext context, IJwtService jwtService) : IRequestHandler<AdminLoginCommand, AdminLoginResponse>
{
    public async Task<AdminLoginResponse> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Administrators.FirstOrDefaultAsync(x => x.Username.ToLower() == request.Username.ToLower());
        if (user == null)
            throw new UserNotFoundException("User not found");
        if (user.Password != request.Password)
        {
            throw new UnauthorizedAccessException();
        }
        //Valid user.
        string[] roles = ["Administrator", "Voter"];
        var generatedJwt = jwtService.GenerateToken(user.Id, roles);
        var res = new AdminLoginResponse(Jwt: generatedJwt);
        return res;
    }
}
