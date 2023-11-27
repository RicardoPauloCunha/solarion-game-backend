using Microsoft.AspNetCore.Authorization;
using SolarionGame.Api.Configurations.Auth.Requirement;
using SolarionGame.Api.Configurations.Auth.Token;
using SolarionGame.Domain.AggregatesService.EmailAggregate.Services;
using SolarionGame.Infrastructure.Mail.EmailAggregate;
using System.Reflection;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class DependencyInjectionStartup
    {
        public static void AddCustomDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            // Dependencies
            services.AddAutoMapper(typeof(Program).Assembly);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Auth
            services.AddScoped<IAuthorizationHandler, AuthorizationRequirementHandler>();
            services.AddScoped<IJwtToken, JwtToken>();

            // Services
            bool activeMail = config.GetValue<bool>("MailSetting:ActiveMail");

            if (activeMail)
                services.AddScoped<IEmailService, EmailService>();
            else
                services.AddScoped<IEmailService, FakeEmailService>();
        }
    }
}
