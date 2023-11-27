using MediatR;
using Microsoft.AspNetCore.Identity;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;
using SolarionGame.Domain.SeedWork;
using System.Net;

namespace SolarionGame.Api.Requests.UserAggregate.EditUserPassword
{
    public class EditUserPasswordHandler : IRequestHandler<EditUserPasswordRequest, ResultWrapper>
    {
        private readonly IRepository _repository;

        public EditUserPasswordHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultWrapper> Handle(EditUserPasswordRequest request, CancellationToken cancellationToken)
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

            #region Senha
            PasswordVerificationResult passwordVerification = new PasswordHasher<string>()
                .VerifyHashedPassword(
                    user.Email,
                    user.Password,
                    request.Password);

            if (passwordVerification == PasswordVerificationResult.Failed)
            {
                return ResultWrapper.GenerateMessage(
                    "Senha inválida.",
                    HttpStatusCode.BadRequest);
            }
            #endregion
            #endregion

            #region Usuário
            string password = new PasswordHasher<string>().HashPassword(
                user.Email,
                request.NewPassword);

            user.SetPassword(password);

            user.Validate();

            _repository.Update<UserModel>(user);
            #endregion

            await _repository.Save();

            #region Retorno
            return ResultWrapper.GenerateMessage(
                "Senha alterada com sucesso.",
                HttpStatusCode.OK);
            #endregion
        }
    }
}
