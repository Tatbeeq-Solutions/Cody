using Cody.Domain.Enums;

namespace Cody.Service.DTOs.Users;

public record UserResultDto(long Id,
                            string FirstName,
                            string LastName,
                            string Email,
                            string Phone,
                            Role Role);
