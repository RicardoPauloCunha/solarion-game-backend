using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Api.Requests.PasswordRecoveryAggregate.ReplyPasswordRecovery;
using SolarionGame.Api.Requests.PasswordRecoveryAggregate.SolicitPasswordRecovery;

namespace SolarionGame.Api.Controllers
{
    [Route("api/password-recoveries")]
    [ApiController]
    [AllowAnonymous]
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PasswordRecoveryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>Solicitar a recuperação de senha</summary>
        /// <param name="request">Dados necessários para a solicitação</param>
        [HttpPost]
        public async Task<IActionResult> SolicitPasswordRecovery([FromBody] SolicitPasswordRecoveryRequest request)
        {
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }

        /// <summary>Responder a solicitação de recuperação de senha</summary>
        /// <param name="request">Dados necessários para a solicitação</param>
        [HttpPut("reply")]
        public async Task<IActionResult> ReplyPasswordRecovery([FromBody] ReplyPasswordRecoveryRequest request)
        {
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }
    }
}
