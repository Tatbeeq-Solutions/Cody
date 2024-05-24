using Cody.Service.Configurations;
using Cody.Service.DTOs.Users;

namespace Cody.Service.Services.Users;

public interface IUserService
{
    Task<UserResultDto> CreateAsync(UserCreateDto createDto);
    Task<UserResultDto> ModifyAsync(long id, UserUpdateDto updateDto);
    Task<bool> RemoveAsync(long id);
    Task<UserResultDto> RetrieveByIdAsync(long id);
    Task<UserResultDto> RetrieveByPhoneAsync(string phone);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params, Filter filter);
    Task<UserResultDto> ChangePasswordAsync(long id, ChangePasswordDto changePasswordDto);
    string GeneratePassword();
}
