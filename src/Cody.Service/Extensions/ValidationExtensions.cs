using Cody.Service.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace Cody.Service.Extensions;

public static class ValidationExtensions
{
    public static async Task<ValidationResult> EnsureValidatedAsync<TValidator, TObject>(this TValidator validator,
        TObject @object)
        where TObject : class
        where TValidator : AbstractValidator<TObject>
    {
        var validationResult = await validator.ValidateAsync(@object);
        if (validationResult.Errors.Count != 0)
            throw new ArgumentIsNotValidException(validationResult.Errors.First().ErrorMessage);

        return validationResult;
    }
}
