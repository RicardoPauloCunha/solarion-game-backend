using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels
{
    public class DecisionViewModel
    {
        public DecisionTypeEnum DecisionType { get; private set; }
        public string DecisionTypeValue { get; private set; }

        public DecisionViewModel(DecisionTypeEnum decisionType)
        {
            DecisionType = decisionType;
            DecisionTypeValue = DecisionTypeEnumValue.GetValue(decisionType);
        }
    }
}
