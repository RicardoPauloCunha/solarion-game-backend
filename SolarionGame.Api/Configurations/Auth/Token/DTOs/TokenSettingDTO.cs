namespace SolarionGame.Api.Configurations.Auth.Token.DTOs
{
    public class TokenSettingDTO
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
