using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarionGame.Api.Configurations.Auth.Token.Utils;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Api.Requests.UserAggregate.CreateCommonUser;
using SolarionGame.Api.Requests.UserAggregate.EditUserData;
using SolarionGame.Api.Requests.UserAggregate.EditUserPassword;
using SolarionGame.Api.Requests.UserAggregate.Login;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Queries;

namespace SolarionGame.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserQuery _userQuery;

        public UserController(IMediator mediator, IUserQuery userQuery)
        {
            _mediator = mediator;
            _userQuery = userQuery;
        }

        /// <summary>Buscar as informações básicas do usuário logado</summary>
        [HttpGet]
        [Authorize]
        public IActionResult GetLoggedUser()
        {
            long userId = TokenUtil.GetUserId(User);

            return Ok(_userQuery.GetLoggedUser(userId));
        }

        /// <summary>Criar usuário comum</summary>
        /// <param name="request">Dados necessários para a solicitação</param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCommonUser([FromBody] CreateCommonUserRequest request)
        {
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }

        /// <summary>Editar dados do usuário</summary>
        /// <param name="request">Dados necessários para a solicitação</param>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditUserData([FromBody] EditUserDataRequest request)
        {
            long userId = TokenUtil.GetUserId(User);

            request.SetComplement(userId);
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }

        /// <summary>Editar senha do usuário</summary>
        /// <param name="request">Dados necessários para a solicitação</param>
        [HttpPut("password")]
        [Authorize]
        public async Task<IActionResult> EditUserPassword([FromBody] EditUserPasswordRequest request)
        {
            long userId = TokenUtil.GetUserId(User);

            request.SetComplement(userId);
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }

        /// <summary>Realizar login</summary>
        /// <param name="request">Dados necessários para a solicitação</param>
        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            ResultWrapper result = await _mediator.Send(request);

            if (result.IsSuccess())
                return Ok(result);
            else
                return base.StatusCode(result.GetStatusCode(), result);
        }
    }
}
