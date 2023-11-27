using FluentValidation;

namespace SolarionGame.Api.Requests.ScoreAggregate.DeleteScore
{
    public class DeleteScoreValidator : AbstractValidator<DeleteScoreRequest>
    {
        public DeleteScoreValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.ScoreId)
                .NotEmpty();
        }
    }
}
