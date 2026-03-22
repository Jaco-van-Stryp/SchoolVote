using System;

namespace SchoolVote.API.Common.Entities;

public class Nominations
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required Gender Gender { get; set; }
    public required int GradeAllocated { get; set; }
    public required string ProfilePictureUrl { get; set; }
    public ICollection<VotersCasted> VotersCasted { get; set; } = new List<VotersCasted>();

}

public enum Gender
{
    Male,
    Female
}
