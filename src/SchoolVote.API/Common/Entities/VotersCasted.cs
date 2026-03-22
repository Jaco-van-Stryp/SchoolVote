using System;

namespace SchoolVote.API.Common.Entities;

public class VotersCasted
{
    public Guid Id { get; init; }
    public required VotingSessions VotingSession { get; set; }
    public required Guid VotingSessionId { get; set; }
    public required Voters Voter { get; set; }
    public required Guid VoterId { get; set; }
    public required Nominations Nominated { get; set; }
    public required Guid NominatedId { get; set; }
    public DateTime DateVoted { get; set; } = DateTime.UtcNow;
}
