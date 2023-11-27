using FluentValidation;

namespace SolarionGame.Api.Requests.UserAggregate.EditUserPassword
{
    public class EditUserPasswordValidator : AbstractValidator<EditUserPasswordRequest>
    {
        public EditUserPasswordValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(24);

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(24);
        }
    }
}
