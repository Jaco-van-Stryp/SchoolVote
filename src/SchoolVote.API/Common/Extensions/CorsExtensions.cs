using SchoolVote.API.Common.Settings;

namespace SchoolVote.API.Common.Extensions;

public static class CorsExtensions
{
    public const string PolicyName = "AllowFrontend";

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("Cors").Get<CorsSettings>()
            ?? throw new InvalidOperationException("Cors configuration is missing.");

        services.Configure<CorsSettings>(configuration.GetSection("Cors"));

        services.AddCors(opts =>
        {
            opts.AddPolicy(PolicyName, policy =>
                policy.WithOrigins(settings.AllowedOrigins)
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials());
        });

        return services;
    }
}
