using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SolarionGame.Api.Configurations.Auth.Token.Enums;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;
using System.Text;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class AuthStartup
    {
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var secret = Encoding.ASCII.GetBytes(config.GetSection("TokenSetting:Secret").Value);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = true,
                    ValidIssuer = config.GetSection("TokenSetting:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = config.GetSection("TokenSetting:Audience").Value
                };
            });
        }

        public static void AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleTypeEnum.Admin, policy => policy.RequireRole(
                    $"{(int)UserTypeEnum.Admin}"));

                options.AddPolicy(RoleTypeEnum.Common, policy => policy.RequireRole(
                    $"{(int)UserTypeEnum.Common}"));

                options.AddPolicy(RoleTypeEnum.All, policy => policy.RequireRole(
                    $"{(int)UserTypeEnum.Admin}",
                    $"{(int)UserTypeEnum.Common}"));
            });
        }
    }
}
