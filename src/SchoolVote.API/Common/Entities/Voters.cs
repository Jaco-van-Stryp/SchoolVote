using System;
using System.Diagnostics.CodeAnalysis;

namespace SchoolVote.API.Common.Entities;

public class Voters
{
    public Guid Id { get; set; }
    public required string AuthKey { get; set; }
    public required string AuthName { get; set; }
    public required int AuthorizedGrade { get; set; }
    public required bool Voted { get; set; } = false;
    public required int MaleVotes { get; set; } = 0;
    public required int FemaleVotes { get; set; } = 0;
    public ICollection<VotersCasted> VotersCasted { get; set; } = new List<VotersCasted>();
}
