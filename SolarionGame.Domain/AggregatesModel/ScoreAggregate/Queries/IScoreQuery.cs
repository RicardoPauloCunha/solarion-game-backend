using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Queries
{
    public interface IScoreQuery
    {
        ScoreIndicatorsViewModel GetScoreIndicators(int? lastMonths, DateTime? startDate, DateTime? endDate);
        List<ScoreViewModel> ListMyScores(long userId, long page);
        List<ScoreViewModel> ListAllScores(long page, List<RatingTypeEnum> ratingTypes, List<HeroTypeEnum> heroTypes, int? lastMonths, DateTime? startDate, DateTime? endDate);
    }
}
