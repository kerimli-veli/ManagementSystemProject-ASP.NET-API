using FluentValidation;
using ManagementSystem.Application.CQRS.Users.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Application.CQRS.Users.Validators;

public class RegisterValidator : AbstractValidator<Register.Command>
{
    public RegisterValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .MaximumLength(255); 

        RuleFor(u => u.Email)
            .NotEmpty()
            .MaximumLength(70)
            .EmailAddress();

        RuleFor(u => u.Password)
            .NotEmpty()
            .MaximumLength(50);
    }
}
