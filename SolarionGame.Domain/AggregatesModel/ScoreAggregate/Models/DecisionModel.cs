using FluentValidation;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Validators;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models
{
    public class DecisionModel
    {
        public DecisionTypeEnum DecisionType { get; private set; }

        public long ScoreId { get; private set; }

        public DecisionModel()
        {
            
        }

        public DecisionModel(DecisionTypeEnum decisionType)
        {
            DecisionType = decisionType;
        }

        public void Validate()
        {
            DecisionValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
