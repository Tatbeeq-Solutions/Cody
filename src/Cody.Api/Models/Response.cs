namespace Cody.Api.Models;

public record Response(string Message,
                       int StatusCode,
                       object Data = null);
