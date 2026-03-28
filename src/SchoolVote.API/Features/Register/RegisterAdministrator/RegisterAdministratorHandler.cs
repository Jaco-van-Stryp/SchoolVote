using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Common.Abstractions;
using SchoolVote.API.Common.Entities;
using SchoolVote.API.Common.Exceptions;
using SchoolVote.API.Infrastructure.Persistence;

namespace SchoolVote.API.Features.Register.RegisterAdministrator;

public class RegisterAdministratorHandler(ApplicationDbContext context, IJwtService jwtService) : IRequestHandler<RegisterAdministratorCommand, RegisterAdministratorResponse>
{
    public async Task<RegisterAdministratorResponse> Handle(RegisterAdministratorCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Administrators.FirstOrDefaultAsync(x => x.Username.ToLower() == request.Username.ToLower(), cancellationToken);
        if (user != null) throw new ConflictException("Username already exists.");
        var newUser = new Administrators
        {
            Username = request.Username.ToLower(),
            Password = request.Password
        };
        await context.AddAsync(newUser);
        await context.SaveChangesAsync();
        string[] Roles = ["Administrator", "Voter"];
        var resJwt = jwtService.GenerateToken(newUser.Id, Roles);
        var res = new RegisterAdministratorResponse(Jwt: resJwt);
        return res;
    }
}
