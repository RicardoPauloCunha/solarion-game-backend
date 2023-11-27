using MediatR;
using Microsoft.AspNetCore.Authorization;
using SolarionGame.Api.Configurations.Auth.Requirement;
using SolarionGame.Api.Configurations.Auth.Token.Utils;
using SolarionGame.Api.Configurations.Wrappers;
using System.Net;

namespace SolarionGame.Api.Requests.UserAggregate.VerifyAuthorization
{
    public class VerifyAuthorizationHandler : IRequestHandler<VerifyAuthorizationRequest, ResultWrapper>
    {
        private readonly IAuthorizationService _authorizationService;

        public VerifyAuthorizationHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<ResultWrapper> Handle(VerifyAuthorizationRequest request, CancellationToken cancellationToken)
        {
            long userId = TokenUtil.GetUserId(request.Claims);

            AuthorizationResult authorized = await _authorizationService.AuthorizeAsync(
                request.Claims,
                userId,
                new AuthorizationRequirement(userId, request.UserType));

            if (authorized.Succeeded)
            {
                return ResultWrapper.GenerateMessage(
                    "Autorização realizada com sucesso.",
                    HttpStatusCode.OK);
            }
            else
            {
                return ResultWrapper.GenerateMessage(
                    "Você não tem autorização para realizar essa operação.",
                    HttpStatusCode.Unauthorized);
            }
        }
    }
}
