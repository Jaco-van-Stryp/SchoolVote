using System.Reflection;
using SchoolVote.API.Common.Abstractions;
using SchoolVote.API.Features.Login;

namespace SchoolVote.API.Common.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var endpointTypes = assembly.GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && t is { IsAbstract: false, IsInterface: false });

        foreach (var type in endpointTypes)
        {
            services.AddTransient(typeof(IEndpoint), type);
        }

        return services;
    }
}
