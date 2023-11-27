using FluentValidation;

namespace SolarionGame.Api.Requests.ScoreAggregate.CreateScore
{
    public class CreateScoreValidator : AbstractValidator<CreateScoreRequest>
    {
        public CreateScoreValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.RatingType)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.HeroType)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.ActionTypes)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Distinct().Count() == x.Count).WithMessage("'ActionTypes' não pode conter valores repetidos.");

            RuleForEach(x => x.ActionTypes)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
