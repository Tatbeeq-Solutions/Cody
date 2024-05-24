using Cody.Service.DTOs.Logins;

namespace Cody.Service.Services.Auths;

public interface IAuthService
{
    Task<LoginResultDto> LoginAsync(LoginDto loginDto);
}
