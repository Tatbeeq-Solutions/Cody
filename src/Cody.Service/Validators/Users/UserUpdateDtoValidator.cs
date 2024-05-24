using Cody.Service.DTOs.Users;
using Cody.Service.Helpers;
using FluentValidation;

namespace Cody.Service.Validators.Users;

public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateDtoValidator()
    {
        RuleFor(user => user.FirstName)
            .NotEmpty()
            .WithMessage(user => $"The {nameof(user.FirstName)} cannot be empty");

        RuleFor(user => user.LastName)
            .NotEmpty()
            .WithMessage(user => $"The {nameof(user.LastName)} cannot be empty");

        RuleFor(user => user.Phone)
            .NotEmpty()
            .Must(ValidationHelper.IsPhoneValid)
            .WithMessage(user => $"The {nameof(user.Phone)} is invalid");
    }
}
