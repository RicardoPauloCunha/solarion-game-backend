namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels
{
    public class ChartValueViewModel
    {
        public string Column { get; private set; }
        public float Value { get; private set; }

        public ChartValueViewModel(string column, float value)
        {
            Column = column;
            Value = value;
        }

        public void SetValue(float value)
        {
            Value = value;
        }
    }
}
