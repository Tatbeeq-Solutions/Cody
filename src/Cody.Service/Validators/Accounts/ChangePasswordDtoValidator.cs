using Cody.Service.DTOs.Users;
using Cody.Service.Helpers;
using FluentValidation;

namespace Cody.Service.Validators.Accounts;

public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidator()
    {
        RuleFor(chanhgePassworddto => chanhgePassworddto.NewPassword)
            .NotEmpty()
            .Must(ValidationHelper.IsPasswordHard)
            .WithMessage(chanhgePassworddto => $"The {nameof(chanhgePassworddto.NewPassword)} is not strong enough");
    }
}
