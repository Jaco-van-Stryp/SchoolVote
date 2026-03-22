using Microsoft.EntityFrameworkCore;
using SchoolVote.API.Common.Entities;
using System.Reflection;

namespace SchoolVote.API.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Administrators> Administrators { get; set; } = null!;
    public DbSet<Nominations> Nominations { get; set; } = null!;
    public DbSet<Voters> Voters { get; set; } = null!;
    public DbSet<VotersCasted> VotesCasted { get; set; } = null!;
    public DbSet<VotingSessions> VotingSessions { get; set; } = null!;

}
