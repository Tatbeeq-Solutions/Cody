namespace Cody.Service.Exceptions;

public class CustomException : Exception
{
    public CustomException() { }

    public CustomException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public CustomException(string message, int statusCode, Exception exception)
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; set; }

    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
