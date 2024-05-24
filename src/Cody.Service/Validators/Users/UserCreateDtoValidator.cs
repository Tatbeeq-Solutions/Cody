using Cody.Service.DTOs.Users;
using Cody.Service.Helpers;
using FluentValidation;

namespace Cody.Service.Validators.Users;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
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

        RuleFor(user => user.Password)
            .NotEmpty()
            .Must(ValidationHelper.IsPasswordHard)
            .WithMessage(user => $"The {nameof(user.Password)} is not strong enough");
    }
}
