using FluentValidation;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Validators;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models
{
    public class ScoreModel
    {
        public long ScoreId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public RatingTypeEnum RatingType { get; private set; }
        public HeroTypeEnum HeroType { get; private set; }
        public List<DecisionModel> Decisions { get; private set; }

        public long UserId { get; private set; }
        public UserModel User { get; init; }

        public ScoreModel()
        {
            
        }

        public ScoreModel(RatingTypeEnum ratingType, HeroTypeEnum heroType, long userId, List<DecisionModel> decisions)
        {
            CreationDate = DateTime.Now;
            RatingType = ratingType;
            HeroType = heroType;
            Decisions = decisions;
            UserId = userId;
        }

        public void Validate()
        {
            ScoreValidator validator = new();
            validator.ValidateAndThrow(this);
        }
    }
}
