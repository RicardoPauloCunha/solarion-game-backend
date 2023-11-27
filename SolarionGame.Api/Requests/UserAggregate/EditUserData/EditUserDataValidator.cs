using FluentValidation;

namespace SolarionGame.Api.Requests.UserAggregate.EditUserData
{
    public class EditUserDataValidator : AbstractValidator<EditUserDataRequest>
    {
        public EditUserDataValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

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
        }
    }
}
