using FluentValidation;

namespace SolarionGame.Api.Requests.PasswordRecoveryAggregate.ReplyPasswordRecovery
{
    public class ReplyPasswordRecoveryValidator : AbstractValidator<ReplyPasswordRecoveryRequest>
    {
        public ReplyPasswordRecoveryValidator()
        {
            RuleFor(x => x.VerificationCode)
                .NotEmpty()
                .NotNull()
                .Length(6);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MinimumLength(3)
                .MaximumLength(80);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(24);
        }
    }
}
