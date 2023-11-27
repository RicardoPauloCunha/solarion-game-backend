using FluentValidation;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Validators
{
    internal class PasswordRecoveryValidator : AbstractValidator<PasswordRecoveryModel>
    {
        public PasswordRecoveryValidator()
        {
            RuleFor(x => x.VerificationCode)
                .NotNull()
                .NotEmpty()
                .Length(6);

            RuleFor(x => x.Active)
                .NotNull();

            RuleFor(x => x.CreationDate)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();
        }
    }
}
