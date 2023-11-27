using MediatR;
using Microsoft.AspNetCore.Identity;
using SolarionGame.Api.Configurations.Auth.Token;
using SolarionGame.Api.Configurations.Auth.Token.DTOs;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using System.Net;

namespace SolarionGame.Api.Requests.UserAggregate.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, ResultWrapper>
    {
        private readonly IJwtToken _jwtToken;
        private readonly IUserRepository _userRepository;

        public LoginHandler(IJwtToken jwtToken, IUserRepository userRepository)
        {
            _jwtToken = jwtToken;
            _userRepository = userRepository;
        }

        public Task<ResultWrapper> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            #region Email
            UserModel user = _userRepository.GetByEmail(request.Email);

            if (user == null)
            {
                return Task.FromResult(ResultWrapper.GenerateMessage(
                    "Usuário não encontrado.",
                    HttpStatusCode.BadRequest));
            }
            #endregion

            #region Senha
            PasswordVerificationResult passwordVerification = new PasswordHasher<string>()
                .VerifyHashedPassword(
                    request.Email,
                    user.Password,
                    request.Password);

            if (passwordVerification == PasswordVerificationResult.Failed)
            {
                return Task.FromResult(ResultWrapper.GenerateMessage(
                    "Email e/ou senha inválida.",
                    HttpStatusCode.BadRequest));
            }
            #endregion
            #endregion

            #region Token
            AuthenticatedDTO authenticated = new(
                user.UserId,
                user.Name,
                user.UserType);

            string tokenResult = _jwtToken.Generate(authenticated);
            #endregion

            #region Retorno
            return Task.FromResult(ResultWrapper.GenerateResult(
                "Login realizado com sucesso.",
                HttpStatusCode.OK,
                tokenResult));
            #endregion
        }
    }
}
