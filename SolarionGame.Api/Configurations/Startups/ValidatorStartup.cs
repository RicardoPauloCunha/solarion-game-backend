using FluentValidation;
using SolarionGame.Api.Requests.PasswordRecoveryAggregate.ReplyPasswordRecovery;
using SolarionGame.Api.Requests.PasswordRecoveryAggregate.SolicitPasswordRecovery;
using SolarionGame.Api.Requests.ScoreAggregate.CreateScore;
using SolarionGame.Api.Requests.ScoreAggregate.DeleteScore;
using SolarionGame.Api.Requests.UserAggregate.CreateCommonUser;
using SolarionGame.Api.Requests.UserAggregate.EditUserData;
using SolarionGame.Api.Requests.UserAggregate.EditUserPassword;
using SolarionGame.Api.Requests.UserAggregate.Login;
using SolarionGame.Api.Requests.UserAggregate.VerifyAuthorization;
using System.Globalization;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class ValidatorStartup
    {
        public static void AddCustomValidatorLanguage(this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddScoped(typeof(IValidator<ReplyPasswordRecoveryRequest>), typeof(ReplyPasswordRecoveryValidator));
            services.AddScoped(typeof(IValidator<SolicitPasswordRecoveryRequest>), typeof(SolicitPasswordRecoveryValidator));
            services.AddScoped(typeof(IValidator<CreateScoreRequest>), typeof(CreateScoreValidator));
            services.AddScoped(typeof(IValidator<DeleteScoreRequest>), typeof(DeleteScoreValidator));
            services.AddScoped(typeof(IValidator<CreateCommonUserRequest>), typeof(CreateCommonUserValidator));
            services.AddScoped(typeof(IValidator<EditUserDataRequest>), typeof(EditUserDataValidator));
            services.AddScoped(typeof(IValidator<EditUserPasswordRequest>), typeof(EditUserPasswordValidator));
            services.AddScoped(typeof(IValidator<LoginRequest>), typeof(LoginValidator));
            services.AddScoped(typeof(IValidator<VerifyAuthorizationRequest>), typeof(VerifyAuthorizationValidator));
        }
    }
}
