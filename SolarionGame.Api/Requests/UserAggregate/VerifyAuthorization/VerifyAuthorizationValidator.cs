using FluentValidation;

namespace SolarionGame.Api.Requests.UserAggregate.VerifyAuthorization
{
    public class VerifyAuthorizationValidator : AbstractValidator<VerifyAuthorizationRequest>
    {
        public VerifyAuthorizationValidator()
        {
            RuleFor(x => x.Claims)
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.UserType)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
