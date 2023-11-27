using FluentValidation;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Validators;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models
{
    public class DecisionModel
    {
        public ActionTypeEnum ActionType { get; private set; }

        public long ScoreId { get; private set; }

        public DecisionModel()
        {
            
        }

        public DecisionModel(ActionTypeEnum actionType)
        {
            ActionType = actionType;
        }

        public void Validate()
        {
            DecisionValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
