namespace Cody.Service.DTOs.Users;

public record UserUpdateDto(string FirstName,
                            string LastName,
                            string Email,
                            string Phone);
