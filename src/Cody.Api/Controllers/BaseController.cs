using Cody.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cody.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public abstract class BaseController : ControllerBase
{
    public long UserId => HttpContextHelper.UserId;
}
