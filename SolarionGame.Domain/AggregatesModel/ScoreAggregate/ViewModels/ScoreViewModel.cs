using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels
{
    public class ScoreViewModel
    {
        public long ScoreId { get; private set; }
        public string CreationDate { get; private set; }
        public HeroTypeEnum HeroType { get; private set; }
        public string HeroTypeValue { get; private set; }
        public RatingTypeEnum RatingType { get; private set; }
        public string RatingTypeValue { get; private set; }
        public IEnumerable<DecisionViewModel> Decisions { get; private set; }
        public string UserName { get; private set; }

        private ScoreViewModel(long scoreId, DateTime creationDate, HeroTypeEnum heroType, RatingTypeEnum ratingType, string userName)
        {
            ScoreId = scoreId;
            CreationDate = creationDate.ToString("HH:mm dd/MM/yyyy");
            HeroType = heroType;
            HeroTypeValue = HeroTypeEnumValue.GetValue(heroType);
            RatingType = ratingType;
            RatingTypeValue = RatingTypeEnumValue.GetValue(ratingType);
            UserName = userName;
        }

        public ScoreViewModel(long scoreId, DateTime creationDate, HeroTypeEnum heroType, RatingTypeEnum ratingType, IEnumerable<DecisionViewModel> decisions, string userName) : this(scoreId, creationDate, heroType, ratingType, userName)
        {
            Decisions = decisions;
        }

        public ScoreViewModel(ScoreModel score) : this(score.ScoreId, score.CreationDate, score.HeroType, score.RatingType, "")
        {
            List<DecisionViewModel> decisions = score.Decisions.Select(x => new DecisionViewModel(
                x.DecisionType )).ToList();

            Decisions = decisions;
        }
    }
}
