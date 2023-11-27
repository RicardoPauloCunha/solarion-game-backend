using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Repositories;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using SolarionGame.Domain.AggregatesService.EmailAggregate.Enums;
using SolarionGame.Domain.AggregatesService.EmailAggregate.Services;
using SolarionGame.Domain.SeedWork;
using System.Net;

namespace SolarionGame.Api.Requests.PasswordRecoveryAggregate.SolicitPasswordRecovery
{
    public class SolicitPasswordRecoveryHandler : IRequestHandler<SolicitPasswordRecoveryRequest, ResultWrapper>
    {
        private readonly IRepository _repository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordRecoveryRepository _passwordRecoveryRepository;

        public SolicitPasswordRecoveryHandler(IRepository repository, IEmailService emailService, IUserRepository userRepository, IPasswordRecoveryRepository passwordRecoveryRepository)
        {
            _repository = repository;
            _emailService = emailService;
            _userRepository = userRepository;
            _passwordRecoveryRepository = passwordRecoveryRepository;
        }

        public async Task<ResultWrapper> Handle(SolicitPasswordRecoveryRequest request, CancellationToken cancellationToken)
        {
            #region Validações
            long userId = _userRepository.GetIdByEmail(request.Email);

            if (userId == 0)
            {
                return ResultWrapper.GenerateMessage(
                    "Usuário não encontrado.",
                    HttpStatusCode.BadRequest);
            }
            #endregion

            PasswordRecoveryModel passwordRecovery = _passwordRecoveryRepository.GetActiveByUserId(userId);

            #region Solicitação de recuperação
            if (passwordRecovery != null)
            {
                if (passwordRecovery.DurationIsValid())
                {
                    passwordRecovery.UpdateCreationDate();

                    passwordRecovery.Validate();

                    _repository.Update<PasswordRecoveryModel>(passwordRecovery);
                }
                else
                {
                    passwordRecovery.Disable();

                    _repository.Update<PasswordRecoveryModel>(passwordRecovery);

                    passwordRecovery = null;
                }
            }

            if (passwordRecovery == null)
            {
                passwordRecovery = new PasswordRecoveryModel(userId);

                passwordRecovery.Validate();

                _repository.Create<PasswordRecoveryModel>(passwordRecovery);
            }
            #endregion

            #region Email
            try
            {
                await _emailService.Send(request.Email, EmailTemplateEnum.PasswordRecovery, passwordRecovery.VerificationCode);
            }
            catch (Exception)
            {
                return ResultWrapper.GenerateMessage(
                    "Ocorreu um erro ao enviar o email com o código de verificação.",
                    HttpStatusCode.BadRequest);
            }
            #endregion

            await _repository.Save();

            #region Retorno
            return ResultWrapper.GenerateMessage(
                "Solicitação de recuperação de senha realizada com sucesso.",
                HttpStatusCode.OK);
            #endregion
        }
    }
}
