using Cody.Api.Models;
using Cody.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Cody.Api.Middlewares;

public class ExceptionHandlerMiddleWare(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (AlreadyExistException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response(ex.Message, ex.StatusCode));

        }
        catch (ArgumentIsNotValidException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response(ex.Message, ex.StatusCode));
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response(ex.Message, ex.StatusCode));
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response(ex.Message, ex.StatusCode));
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response(ex.Message, 500));
        }
    }
}
