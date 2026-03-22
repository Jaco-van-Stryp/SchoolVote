using System;
using SchoolVote.API.Features.Register.RegisterAdministrator;

namespace SchoolVote.API.Features.Register;

public static class RegisterAdministratorEndpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/Register").WithName("Register");
        group.MapRegisterAdministratorEnpoint();
        return app;
    }
}
