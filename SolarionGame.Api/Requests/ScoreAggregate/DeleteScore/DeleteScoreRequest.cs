using MediatR;
using SolarionGame.Api.Configurations.Wrappers;

namespace SolarionGame.Api.Requests.ScoreAggregate.DeleteScore
{
    public class DeleteScoreRequest : IRequest<ResultWrapper>
    {
        public long UserId { get; private set; }
        public long ScoreId { get; private set; }

        public DeleteScoreRequest()
        {
            
        }

        public DeleteScoreRequest(long userId, long scoreId)
        {
            UserId = userId;
            ScoreId = scoreId;
        }
    }
}
