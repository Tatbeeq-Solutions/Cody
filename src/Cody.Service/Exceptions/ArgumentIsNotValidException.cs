namespace Cody.Service.Exceptions;

public class ArgumentIsNotValidException : Exception
{
    public ArgumentIsNotValidException() { }

    public ArgumentIsNotValidException(string message) : base(message) { }

    public ArgumentIsNotValidException(string message, Exception exception) { }

    public static int StatusCode => 400;
}