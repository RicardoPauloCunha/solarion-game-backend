using SolarionGame.Api.Configurations.Auth.Token.DTOs;

namespace SolarionGame.Api.Configurations.Auth.Token
{
    public interface IJwtToken
    {
        string Generate(AuthenticatedDTO authenticated);
    }
}
