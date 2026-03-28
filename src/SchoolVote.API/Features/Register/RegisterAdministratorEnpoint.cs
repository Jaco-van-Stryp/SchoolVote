using System;
using SchoolVote.API.Features.Register.RegisterAdministrator;
using SchoolVote.API.Features.Register.RegisterVoter;

namespace SchoolVote.API.Features.Register;

public static class RegisterAdministratorEndpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/Register").WithTags("Register");
        group.MapRegisterAdministratorEnpoint();
        group.MapRegisterVoterEndpoint();
        return app;
    }
}
