using FluentValidation;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Validators
{
    internal class DecisionValidator : AbstractValidator<DecisionModel>
    {
        public DecisionValidator()
        {
            RuleFor(x => x.ActionType)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
