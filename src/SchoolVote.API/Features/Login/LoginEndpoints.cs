using System;
using SchoolVote.API.Features.Login.AdminLogin;
using SchoolVote.API.Features.Login.VoterLogin;

namespace SchoolVote.API.Features.Login;

public static class LoginEndpoints
{
    public static IEndpointRouteBuilder MapLoginEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/Login").WithTags("Login");
        group.MapAdminLoginEndpoint();
        group.MapVoterLoginEndpoint();
        return app;
    }
}
