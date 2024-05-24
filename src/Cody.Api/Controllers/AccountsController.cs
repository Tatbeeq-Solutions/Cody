using Cody.Api.Models;
using Cody.Service.DTOs.Logins;
using Cody.Service.DTOs.Users;
using Cody.Service.Services.Auths;
using Cody.Service.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cody.Api.Controllers;

public class AccountsController(IAuthService authService, IUserService userService) : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
    {
        return Ok(new Response("Ok",
                               200,
                               await authService.LoginAsync(loginDto)));
    }

    [HttpPatch("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(long id, [FromBody] ChangePasswordDto changePasswordDto)
    {
        return Ok(new Response("Ok",
                               200,
                               await userService.ChangePasswordAsync(id, changePasswordDto)));
    }

    [HttpGet("generate-strong-password")]
    [AllowAnonymous]
    public IActionResult GeneratePassword()
    {
        return Ok(new Response("Ok",
                               200,
                               userService.GeneratePassword()));
    }
}
