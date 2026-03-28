namespace SchoolVote.API.Common.Exceptions;

public class UserNotFoundException(string message) : NotFoundException(message);
