namespace SchoolVote.API.Common.Abstractions;

public interface IJwtService
{
    string GenerateToken(Guid userId, string email, IEnumerable<string> roles);
}
