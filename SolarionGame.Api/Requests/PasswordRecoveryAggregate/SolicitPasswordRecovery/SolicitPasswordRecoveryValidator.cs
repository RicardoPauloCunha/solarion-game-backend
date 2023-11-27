using FluentValidation;

namespace SolarionGame.Api.Requests.PasswordRecoveryAggregate.SolicitPasswordRecovery
{
    public class SolicitPasswordRecoveryValidator : AbstractValidator<SolicitPasswordRecoveryRequest>
    {
        public SolicitPasswordRecoveryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MinimumLength(3)
                .MaximumLength(80);
        }
    }
}
