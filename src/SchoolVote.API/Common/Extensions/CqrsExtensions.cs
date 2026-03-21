using FluentValidation;
using MediatR;
using SchoolVote.API.Common.Behaviours;

namespace SchoolVote.API.Common.Extensions;

public static class CqrsExtensions
{
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        return services;
    }
}
