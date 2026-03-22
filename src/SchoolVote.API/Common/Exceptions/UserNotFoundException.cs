using System;

namespace SchoolVote.API.Common.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message)
        : base(message)
    { }
}
