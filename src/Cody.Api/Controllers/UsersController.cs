using Cody.Api.Models;
using Cody.Service.Configurations;
using Cody.Service.DTOs.Users;
using Cody.Service.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Cody.Api.Controllers;

public class UsersController(IUserService userService) : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> PostAsync([FromBody] UserCreateDto createDto)
    {
        return Ok(new Response("Ok",
                               200,
                               await userService.CreateAsync(createDto)));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] UserUpdateDto updateDto)
    {
        return Ok(new Response("Ok",
                               200,
                               await userService.ModifyAsync(id, updateDto)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response("Ok",
                               200,
                               await userService.RemoveAsync(id)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response("Ok",
                               200,
                               await userService.RetrieveByIdAsync(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] PaginationParams @params, [FromQuery] Filter filter)
    {
        return Ok(new Response("Ok",
                               200,
                               await userService.RetrieveAllAsync(@params, filter)));
    }
}
