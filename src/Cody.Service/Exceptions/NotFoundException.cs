namespace Cody.Service.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() { }

    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception exception) { }

    public static int StatusCode => 404;
}