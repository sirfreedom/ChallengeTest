using System;


public class AppException : Exception
{

    private string _Message = string.Empty;

    public AppException(string message)
    {
        _Message = message;
    }

    public override string Message
    {
        get
        {
            return _Message;
        }
    }
}

