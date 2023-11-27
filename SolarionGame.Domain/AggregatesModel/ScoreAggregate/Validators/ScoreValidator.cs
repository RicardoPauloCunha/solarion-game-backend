using FluentValidation;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Validators
{
    internal class ScoreValidator : AbstractValidator<ScoreModel>
    {
        public ScoreValidator()
        {
            RuleFor(x => x.CreationDate)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.RatingType)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.HeroType)
                .NotEmpty()
                .IsInEnum();

            RuleFor(x => x.Decisions)
                .NotEmpty()
                .NotNull();

            RuleForEach(x => x.Decisions)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
