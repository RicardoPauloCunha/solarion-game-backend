namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels
{
    public class ChartViewModel
    {
        public string Description { get; private set; }
        public float TotalValue { get; private set; }
        public List<ChartValueViewModel> Values { get; private set; }

        public ChartViewModel(string description, float totalValue)
        {
            Description = description;
            TotalValue = totalValue;
        }

        public ChartViewModel(string description, float totalValue, List<ChartValueViewModel> values) : this(description, totalValue)
        {
            Values = values;
        }
    }
}
