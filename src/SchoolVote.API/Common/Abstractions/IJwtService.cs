namespace SchoolVote.API.Common.Abstractions;

public interface IJwtService
{
    string GenerateToken(Guid userId, IEnumerable<string> roles);
}
