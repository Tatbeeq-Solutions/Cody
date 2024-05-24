namespace Cody.Service.DTOs.Users;

public record UserCreateDto(string FirstName,
                            string LastName,
                            string Email,
                            string Phone,
                            string Password);
