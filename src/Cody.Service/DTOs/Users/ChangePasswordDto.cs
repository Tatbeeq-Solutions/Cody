namespace Cody.Service.DTOs.Users;

public record ChangePasswordDto(string OldPassword,
                                string NewPassword);
