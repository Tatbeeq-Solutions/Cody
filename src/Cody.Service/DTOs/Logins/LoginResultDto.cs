using Cody.Service.DTOs.Users;

namespace Cody.Service.DTOs.Logins;

public record LoginResultDto(object User,
                             string Token);
