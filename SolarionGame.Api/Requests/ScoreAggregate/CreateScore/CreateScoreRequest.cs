using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using System.Runtime.Serialization;

namespace SolarionGame.Api.Requests.ScoreAggregate.CreateScore
{
    [DataContract]
    public class CreateScoreRequest : IRequest<ResultWrapper>
    {
        public long UserId { get; private set; }

        [DataMember]
        public RatingTypeEnum RatingType { get; set; }

        [DataMember]
        public HeroTypeEnum HeroType { get; set; }

        [DataMember]
        public List<ActionTypeEnum> ActionTypes { get; set; }

        public CreateScoreRequest()
        {
            
        }

        public void SetComplement(long userId)
        {
            UserId = userId;
        }
    }
}
