using MediatR;
using Microsoft.AspNetCore.Identity;
using SolarionGame.Api.Configurations.Auth.Token;
using SolarionGame.Api.Configurations.Auth.Token.DTOs;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using SolarionGame.Domain.SeedWork;
using System.Net;

namespace SolarionGame.Api.Requests.UserAggregate.CreateCommonUser
{
    public class CreateCommonUserHandler : IRequestHandler<CreateCommonUserRequest, ResultWrapper>
    {
        private readonly IJwtToken _jwtToken;
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;

        public CreateCommonUserHandler(IJwtToken jwtToken, IRepository repository, IUserRepository userRepository)
        {
            _jwtToken = jwtToken;
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<ResultWrapper> Handle(CreateCommonUserRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            bool emailExists = _userRepository.ExistsByEmail(request.Email);
            
            if (emailExists)
            {
                return ResultWrapper.GenerateMessage(
                    "Email já cadastrado no sistema.",
                    HttpStatusCode.BadRequest);
            }
            #endregion

            #region Usuário
            string password = new PasswordHasher<string>().HashPassword(
                request.Email,
                request.Password);

            UserModel user = new(
                request.Name,
                request.Email,
                password,
                UserTypeEnum.Common);

            user.Validate();

            _repository.Create(user);
            #endregion

            await _repository.Save();

            #region Token
            AuthenticatedDTO authenticated = new(
                user.UserId,
                user.Name,
                user.UserType);

            string tokenResult = _jwtToken.Generate(authenticated);
            #endregion

            #region Retorno
            return ResultWrapper.GenerateResult(
                "Usuário criado com sucesso.",
                HttpStatusCode.OK,
                tokenResult);
            #endregion
        }
    }
}
