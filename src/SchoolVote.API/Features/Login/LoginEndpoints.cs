using System;
using SchoolVote.API.Features.Login.AdminLogin;

namespace SchoolVote.API.Features.Login;

public static class LoginEndpoints
{
    public static IEndpointRouteBuilder MapLoginEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/Login").WithTags("Login");
        group.MapAdminLoginEndpoint();
        return app;
    }
}
