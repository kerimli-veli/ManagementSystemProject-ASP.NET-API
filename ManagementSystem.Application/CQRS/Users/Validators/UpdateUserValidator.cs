using FluentValidation;
using static ManagementSystem.Application.CQRS.Users.Handlers.Register;

namespace ManagementSystem.Application.CQRS.Users.Validators;

public class UpdateUserValidator : AbstractValidator<Command>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .MaximumLength(255);

        RuleFor(u => u.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(70);

    }
}
