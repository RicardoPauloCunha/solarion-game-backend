using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;
using SolarionGame.Domain.AggregatesService.EmailAggregate.Enums;
using SolarionGame.Domain.AggregatesService.EmailAggregate.Services;

namespace SolarionGame.Infrastructure.Mail.EmailAggregate
{
    public class EmailService : IEmailService
    {
        private readonly string TEMPLATES_PATH = $"{Directory.GetCurrentDirectory()}/wwwroot/email-templates/";

        private readonly IServiceProvider _serviceProvider;

        public EmailService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Send(string recipientEmail, EmailTemplateEnum emailTemplate, string textToReplace)
        {
            using var scope = _serviceProvider.CreateScope();
            var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();

            var messages = EmailTemplateEnumValue.GetValue(emailTemplate, textToReplace);

            var email = mailer.To(recipientEmail)
                .Subject("Recuperação de senha")
                .UsingTemplateFromFile(TEMPLATES_PATH + "default-email-template.cshtml", new
                {
                    Messages = messages
                });

            await email.SendAsync();
        }
    }
}
