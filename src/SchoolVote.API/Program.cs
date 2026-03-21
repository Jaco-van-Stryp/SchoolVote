using Serilog;
using SchoolVote.API.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));

builder.Services
    .AddDatabase(builder.Configuration)
    .AddJwtAuthentication(builder.Configuration)
    .AddCqrs()
    .AddCorsPolicy(builder.Configuration)
    .AddOpenApiDocs("SchoolVote API")
    .AddEndpoints(typeof(Program).Assembly);

var app = builder.Build();

app.UseExceptionHandling()
   .UseCors(CorsExtensions.PolicyName)
   .UseAuthentication()
   .UseAuthorization();

app.MapEndpoints();
app.UseOpenApiDocs();

app.Run();
