using System.Net;
using System.Net.Mail;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class MailStartup
    {
        public static void AddCustomMail(this IServiceCollection services, IConfiguration config)
        {
            var senderName = config.GetSection("MailSetting:Sender:Name").Value;
            var senderEmail = config.GetSection("MailSetting:Sender:Email").Value;
            var senderPassword = config.GetSection("MailSetting:Sender:Password").Value;
            var smtpHost = config.GetSection("MailSetting:Smtp:Host").Value;
            var smtpPort = Convert.ToInt32(config.GetSection("MailSetting:Smtp:Port").Value);

            services.AddFluentEmail(senderEmail, senderName)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient(smtpHost)
                {
                    UseDefaultCredentials = false,
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                });
        }
    }
}
