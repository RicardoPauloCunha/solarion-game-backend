using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SolarionGame.Api.Configurations.Auth.Token.DTOs;
using SolarionGame.Api.Configurations.Auth.Token.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SolarionGame.Api.Configurations.Auth.Token
{
    public class JwtToken : IJwtToken
    {
        private readonly TokenSettingDTO _tokenSetting;

        public JwtToken(IOptionsMonitor<TokenSettingDTO> optionsMonitor)
        {
            _tokenSetting = optionsMonitor.CurrentValue;
        }

        public string Generate(AuthenticatedDTO authenticated)
        {
            var secret = Encoding.ASCII.GetBytes(_tokenSetting.Secret);
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);

            var claims = new[]
            {
                new Claim(ClaimTypeEnum.UserId, authenticated.UserId),
                new Claim(ClaimTypeEnum.UserName, authenticated.UserName),
                new Claim(ClaimTypeEnum.UserType, authenticated.UserType),
                new Claim(ClaimTypes.Role, authenticated.UserType),
            };

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.Add(TimeSpan.FromDays(3)),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256),
                Issuer = _tokenSetting.Issuer,
                Audience = _tokenSetting.Audience
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }
    }
}
