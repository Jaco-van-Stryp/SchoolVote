using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Infrastructure.Persistence;

namespace SchoolVote.API.Common.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseNpgsql(connectionString));

        return services;
    }
}
