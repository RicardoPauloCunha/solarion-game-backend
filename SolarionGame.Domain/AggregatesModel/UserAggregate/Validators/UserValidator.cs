using FluentValidation;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.UserAggregate.Validators
{
    internal class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(40);

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MinimumLength(3)
                .MaximumLength(80);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(124);

            RuleFor(x => x.CreationDate)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.UserType)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
