using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using SolarionGame.Domain.SeedWork;
using System.Net;

namespace SolarionGame.Api.Requests.ScoreAggregate.CreateScore
{
    public class CreateScoreHandler : IRequestHandler<CreateScoreRequest, ResultWrapper>
    {
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;

        public CreateScoreHandler(IRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<ResultWrapper> Handle(CreateScoreRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            bool exists = _userRepository.ExistsById(request.UserId);

            if (!exists)
            {
                return ResultWrapper.GenerateMessage(
                    "Usuário não encontrado.",
                    HttpStatusCode.BadRequest);
            }
            #endregion

            #region Decisões
            List<DecisionModel> decisions = new();

            request.ActionTypes.ForEach(x =>
            {
                DecisionModel decision = new(x);

                decision.Validate();

                decisions.Add(decision);
            });
            #endregion

            #region Pontuação
            ScoreModel score = new(
                request.RatingType,
                request.HeroType,
                request.UserId,
                decisions);

            score.Validate();

            _repository.Create<ScoreModel>(score);
            #endregion

            await _repository.Save();

            #region Retorno
            var result = new ScoreViewModel(
                score);

            return ResultWrapper.GenerateResult(
                "Pontuação criada com sucesso.",
                HttpStatusCode.OK,
                result);
            #endregion
        }
    }
}
