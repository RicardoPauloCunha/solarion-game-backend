using SolarionGame.Domain.AggregatesService.EmailAggregate.Enums;
using SolarionGame.Domain.AggregatesService.EmailAggregate.Services;

namespace SolarionGame.Infrastructure.Mail.EmailAggregate
{
    public class FakeEmailService : IEmailService
    {
        public FakeEmailService()
        {

        }

        public Task Send(string recipientEmail, EmailTemplateEnum emailTemplate, string textToReplace)
        {
            return Task.CompletedTask;
        }
    }
}
