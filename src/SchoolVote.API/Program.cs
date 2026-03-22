using Serilog;
using SchoolVote.API.Common.Extensions;
using SchoolVote.API.Features;

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

app.MapAllEndpoints();
app.UseOpenApiDocs();

app.Run();
