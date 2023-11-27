using SolarionGame.Api.Configurations.Auth.Token.DTOs;
using SolarionGame.Domain.AggregatesService.AppAggregate.DTOs;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class SettingStartup
    {
        public static void AddCustomSetting(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<TokenSettingDTO>(config.GetSection("TokenSetting"));
            services.Configure<AppSettingDTO>(config.GetSection("AppSetting"));
        }
    }
}
