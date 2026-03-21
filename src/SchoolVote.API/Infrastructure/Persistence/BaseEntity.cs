namespace SchoolVote.API.Infrastructure.Persistence;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
