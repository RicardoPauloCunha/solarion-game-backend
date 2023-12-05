using MediatR;
using SolarionGame.Api.Configurations.Auth.Token;
using SolarionGame.Api.Configurations.Auth.Token.DTOs;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using SolarionGame.Domain.SeedWork;
using System.Net;

namespace SolarionGame.Api.Requests.UserAggregate.EditUserData
{
    public class EditUserDataHandler : IRequestHandler<EditUserDataRequest, ResultWrapper>
    {
        private readonly IJwtToken _jwtToken;
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;

        public EditUserDataHandler(IJwtToken jwtToken, IRepository repository, IUserRepository userRepository)
        {
            _jwtToken = jwtToken;
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<ResultWrapper> Handle(EditUserDataRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            #region Id
            UserModel user = _repository.GetById<UserModel>(request.UserId);

            if (user == null)
            {
                return ResultWrapper.GenerateMessage(
                    "Usuário não encontrado.",
                    HttpStatusCode.BadRequest);
            }
            #endregion

            #region Email
            if (user.Email != request.Email.ToUpper())
            {
                bool emailExists = _userRepository.ExistsByEmail(request.Email);

                if (emailExists)
                {
                    return ResultWrapper.GenerateMessage(
                        "Email já cadastrado no sistema.",
                        HttpStatusCode.BadRequest);
                }
            }
            #endregion
            #endregion

            #region Usuário
            user.SetName(request.Name);
            user.SetEmail(request.Email);

            user.Validate();

            _repository.Update<UserModel>(user);
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
                "Dados do usuário editados com sucesso.",
                HttpStatusCode.OK,
                tokenResult);
            #endregion
        }
    }
}
