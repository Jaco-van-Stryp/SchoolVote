using System;

namespace SchoolVote.API.Common.Entities;

public class VotingSessions
{
    public Guid Id { get; init; }
    public required string VotingSessionName { get; set; }
    public required Administrators Administrator { get; set; }
    public required Guid AdministratorId { get; set; }

    //Everything in this app is linked to a Voting Session, which the admin can create.
    public ICollection<Voters> Voters { get; set; } = new List<Voters>();
    public ICollection<Nominations> Nominations { get; set; } = new List<Nominations>();
    public ICollection<VotersCasted> VotersCasted { get; set; } = new List<VotersCasted>();

}
