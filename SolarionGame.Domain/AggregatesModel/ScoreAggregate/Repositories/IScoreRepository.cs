using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Repositories
{
    public interface IScoreRepository
    {
        ScoreModel GetCompleteById(long id);
    }
}
