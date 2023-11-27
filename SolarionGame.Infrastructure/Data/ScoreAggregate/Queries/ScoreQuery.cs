using Microsoft.EntityFrameworkCore;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Queries;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels;

namespace SolarionGame.Infrastructure.Data.ScoreAggregate.Queries
{
    public class ScoreQuery : IScoreQuery
    {
        private readonly SolarionGameContext _context;

        public ScoreQuery(SolarionGameContext context)
        {
            _context = context;
        }

        public List<ScoreViewModel> ListMyScores(long userId, long page)
        {
            return _context
                .Score
                .AsNoTracking()
                .OrderByDescending(x => x.ScoreId)
                .Where(x => (page == 0 || x.ScoreId < page)
                    && x.UserId == userId)
                .Take(10)
                .Select(x => new ScoreViewModel(
                    x.ScoreId,
                    x.CreationDate,
                    x.HeroType,
                    x.RatingType,
                    x.Decisions.Select(y => new DecisionViewModel(
                        y.ActionType)),
                    ""))
                .ToList();
        }

        public List<ScoreViewModel> ListAllScores(long page, List<RatingTypeEnum> ratingTypes, List<HeroTypeEnum> heroTypes, int? lastMonths, DateTime? _startDate, DateTime? _endDate)
        {
            #region Types
            bool allRatingTypes = ratingTypes == null
                || !ratingTypes.Any()
                || ratingTypes.Count == Enum.GetNames(typeof(RatingTypeEnum)).Length - 1;

            bool allHeroTypes = heroTypes == null
                || !heroTypes.Any()
                || heroTypes.Count == Enum.GetNames(typeof(HeroTypeEnum)).Length - 1;
            #endregion

            #region Data
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = DateTime.Now;

            if (lastMonths != null && lastMonths > 0)
            {
                startDate = startDate.AddMonths(-((int)lastMonths - 1));
            }
            else if (_startDate != null && _endDate != null)
            {
                startDate = (DateTime)_startDate;
                endDate = (DateTime)_endDate;
            }
            #endregion

            return _context
                .Score
                .AsNoTracking()
                .OrderByDescending(x => x.ScoreId)
                .Where(x => (page == 0 || x.ScoreId < page)
                    && (allRatingTypes || ratingTypes.Contains(x.RatingType))
                    && (allHeroTypes || heroTypes.Contains(x.HeroType))
                    && (x.CreationDate.Date >= startDate.Date
                        && x.CreationDate.Date <= endDate.Date))
                .Take(10)
                .Select(x => new ScoreViewModel(
                    x.ScoreId,
                    x.CreationDate,
                    x.HeroType,
                    x.RatingType,
                    x.Decisions.Select(y => new DecisionViewModel(
                        y.ActionType)),
                    x.User.Name))
                .ToList();
        }
    }
}
