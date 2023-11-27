using MediatR;
using Microsoft.AspNetCore.Identity;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Repositories;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using SolarionGame.Domain.SeedWork;
using System.Net;

namespace SolarionGame.Api.Requests.PasswordRecoveryAggregate.ReplyPasswordRecovery
{
    public class ReplyPasswordRecoveryHandler : IRequestHandler<ReplyPasswordRecoveryRequest, ResultWrapper>
    {
        private readonly IRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRecoveryRepository _passwordRecoveryRepository;

        public ReplyPasswordRecoveryHandler(IRepository repository, IUserRepository userRepository, IPasswordRecoveryRepository passwordRecoveryRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _passwordRecoveryRepository = passwordRecoveryRepository;
        }

        public async Task<ResultWrapper> Handle(ReplyPasswordRecoveryRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            #region Email
            UserModel user = _userRepository.GetByEmail(request.Email);

            if (user == null)
            {
                return ResultWrapper.GenerateMessage(
                    "Usuário não encontrado.",
                    HttpStatusCode.BadRequest);
            }
            #endregion

            #region Solicitação recuperação
            PasswordRecoveryModel passwordRecovery = _passwordRecoveryRepository.GetActiveByUserId(user.UserId);

            if (passwordRecovery == null)
            {
                return ResultWrapper.GenerateMessage(
                    "Solicitação de recuperação de senha não encontrada.",
                    HttpStatusCode.BadRequest);
            }

            if (passwordRecovery.VerificationCode != request.VerificationCode)
            {
                return ResultWrapper.GenerateMessage(
                    "Código de verificação inválido.",
                    HttpStatusCode.BadRequest);
            }

            if (!passwordRecovery.DurationIsValid())
            {
                return ResultWrapper.GenerateMessage(
                    "Código de verificação expirado.",
                    HttpStatusCode.BadRequest);
            }
            #endregion
            #endregion

            #region Usuário
            string password = new PasswordHasher<string>().HashPassword(
                user.Email,
                request.Password);

            user.SetPassword(password);

            user.Validate();

            _repository.Update<UserModel>(user);
            #endregion

            #region Recuperação senha
            passwordRecovery.Disable();

            _repository.Update<PasswordRecoveryModel>(passwordRecovery);
            #endregion

            await _repository.Save();

            #region Retorno
            return ResultWrapper.GenerateMessage(
                "Senha recuperada com sucesso.",
                HttpStatusCode.OK);
            #endregion
        }
    }
}
