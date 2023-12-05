using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarionGame.Api.Configurations.Auth.Token.Enums;
using SolarionGame.Api.Configurations.Auth.Token.Utils;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Api.Requests.ScoreAggregate.CreateScore;
using SolarionGame.Api.Requests.ScoreAggregate.DeleteScore;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Queries;

namespace SolarionGame.Api.Controllers
{
    [Route("api/scores")]
    [ApiController]
    [Authorize]
    public class ScoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IScoreQuery _scoreQuery;

        public ScoreController(IMediator mediator, IScoreQuery scoreQuery)
        {
            _mediator = mediator;
            _scoreQuery = scoreQuery;
        }

        /// <summary>Listar as pontuações do usuário</summary>
        [HttpGet]
        [Authorize(Policy = RoleTypeEnum.Common)]
        public IActionResult ListMyScores([FromQuery] long page)
        {
            long userId = TokenUtil.GetUserId(User);

            return Ok(_scoreQuery.ListMyScores(userId, page));
        }

        /// <summary>Criar pontuação do usuário</summary>
        /// <param name="request">Dados necessários para a solicitação</param>
        [HttpPost]
        [Authorize(Policy = RoleTypeEnum.Common)]
        public async Task<IActionResult> CreateScore([FromBody] CreateScoreRequest request)
        {
            long userId = TokenUtil.GetUserId(User);

            request.SetComplement(userId);
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }

        /// <summary>Deletar pontuação do usuário</summary>
        /// <param name="scoreId">Id da pontuação</param>
        [HttpDelete("{scoreId}")]
        [Authorize(Policy = RoleTypeEnum.Common)]
        public async Task<IActionResult> DeleteScore([FromRoute] long scoreId)
        {
            long userId = TokenUtil.GetUserId(User);

            var request = new DeleteScoreRequest(userId, scoreId);
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }

        /// <summary>Listar todas as pontuações</summary>
        [HttpGet("all")]
        [Authorize(Policy = RoleTypeEnum.Admin)]
        public IActionResult ListAllScores(
            [FromQuery] long page,
            [FromQuery(Name = "ratingTypes[]")] List<RatingTypeEnum> ratingTypes,
            [FromQuery(Name = "heroTypes[]")] List<HeroTypeEnum> heroTypes,
            [FromQuery] int? lastMonths,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            return Ok(_scoreQuery.ListAllScores(page, ratingTypes, heroTypes, lastMonths, startDate, endDate));
        }

        /// <summary>Buscar os indicadores das pontuações</summary>
        [HttpGet("all/indicators")]
        [Authorize(Policy = RoleTypeEnum.Admin)]
        public IActionResult GetScoreIndicators(
            [FromQuery] int? lastMonths,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate)
        {
            return Ok(_scoreQuery.GetScoreIndicators(lastMonths, startDate, endDate));
        }
    }
}
