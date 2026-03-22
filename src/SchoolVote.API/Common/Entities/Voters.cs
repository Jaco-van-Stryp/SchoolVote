using System;

namespace SchoolVote.API.Common.Entities;

public class Voters
{
    public Guid Id { get; set; }
    public required string AuthKey { get; set; }
    public required string AuthName { get; set; }
    public required int AuthorizedGrade { get; set; }
    public required bool Voted { get; set; } = false;
    public ICollection<VotersCasted> VotersCasted { get; set; } = new List<VotersCasted>();
}
