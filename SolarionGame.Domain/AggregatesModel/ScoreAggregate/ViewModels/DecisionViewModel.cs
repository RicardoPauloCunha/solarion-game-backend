using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels
{
    public class DecisionViewModel
    {
        public ActionTypeEnum ActionType { get; private set; }
        public string ActionTypeValue { get; private set; }

        public DecisionViewModel(ActionTypeEnum actionType)
        {
            ActionType = actionType;
            ActionTypeValue = ActionTypeEnumValue.GetValue(actionType);
        }
    }
}
