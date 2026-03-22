using System;

namespace SchoolVote.API.Common.Entities;

public class Administrators
{
    public Guid Id { get; init; }
    public required string Username { get; set; }
    public required string Password { get; set; } //For now, we'll just capture plain text, will upgrade this to be more secure later - //TODO
    public ICollection<VotingSessions> votingSessions { get; set; } = new List<VotingSessions>();
}
