﻿namespace ChatNext.Data.Exceptions;

public class UserFriendlyException : Exception
{
    public UserFriendlyException(string message) : base(message)
    {
    }
}