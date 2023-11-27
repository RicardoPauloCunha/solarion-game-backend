using FluentValidation;

namespace SolarionGame.Api.Requests.UserAggregate.CreateCommonUser
{
    public class CreateCommonUserValidator : AbstractValidator<CreateCommonUserRequest>
    {
        public CreateCommonUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(40);

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
