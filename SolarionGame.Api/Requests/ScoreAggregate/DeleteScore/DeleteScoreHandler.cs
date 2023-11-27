using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Repositories;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using SolarionGame.Domain.SeedWork;
using System.Net;

namespace SolarionGame.Api.Requests.ScoreAggregate.DeleteScore
{
    public class DeleteScoreHandler : IRequestHandler<DeleteScoreRequest, ResultWrapper>
    {
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IScoreRepository _scoreRepository;

        public DeleteScoreHandler(IRepository repository, IUserRepository userRepository, IScoreRepository scoreRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _scoreRepository = scoreRepository;
        }

        public async Task<ResultWrapper> Handle(DeleteScoreRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            #region Usuário
            bool exists = _userRepository.ExistsById(request.UserId);

            if (!exists)
            {
                return ResultWrapper.GenerateMessage(
                    "Usuário não encontrado.",
                    HttpStatusCode.BadRequest);
            }
            #endregion

            #region Pontuação
            ScoreModel score = _scoreRepository.GetCompleteById(request.ScoreId);

            if (score == null)
            {
                return ResultWrapper.GenerateMessage(
                    "Pontuação não encontrada.",
                    HttpStatusCode.BadRequest);
            }

            if (score.UserId != request.UserId)
            {
                return ResultWrapper.GenerateMessage(
                    "Pontuação inválida para esse usuário.",
                    HttpStatusCode.BadRequest);
            }
            #endregion
            #endregion

            #region Decisões
            score.Decisions.ForEach(x =>
            {
                _repository.Delete<DecisionModel>(x);
            });
            #endregion

            #region Pontuação
            _repository.Delete<ScoreModel>(score);
            #endregion

            await _repository.Save();

            #region Retorno
            return ResultWrapper.GenerateMessage(
                "Pontuação deletada com sucesso.",
                HttpStatusCode.OK);
            #endregion
        }
    }
}
