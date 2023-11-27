using SolarionGame.Domain.AggregatesService.EmailAggregate.Enums;

namespace SolarionGame.Domain.AggregatesService.EmailAggregate.Services
{
    public interface IEmailService
    {
        Task Send(string recipientEmail, EmailTemplateEnum emailTemplate, string textToReplace);
    }
}
