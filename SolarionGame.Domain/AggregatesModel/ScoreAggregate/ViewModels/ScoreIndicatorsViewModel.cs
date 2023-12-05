namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels
{
    public class ScoreIndicatorsViewModel
    {
        public ChartViewModel AdventuresChart { get; private set; }
        public List<ChartViewModel> HeroCharts { get; private set; }
        public List<ChartViewModel> RatingCharts { get; private set; }

        public ScoreIndicatorsViewModel(ChartViewModel adventuresChart, List<ChartViewModel> heroCharts, List<ChartViewModel> ratingCharts)
        {
            AdventuresChart = adventuresChart;
            HeroCharts = heroCharts;
            RatingCharts = ratingCharts;
        }
    }
}
