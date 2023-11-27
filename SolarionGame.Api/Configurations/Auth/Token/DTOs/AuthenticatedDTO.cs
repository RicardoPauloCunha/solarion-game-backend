using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;

namespace SolarionGame.Api.Configurations.Auth.Token.DTOs
{
    public class AuthenticatedDTO
    {
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string UserType { get; private set; }

        public AuthenticatedDTO(long userId, string userName, UserTypeEnum userType)
        {
            UserId = userId.ToString();
            UserName = userName;
            UserType = ((int)userType).ToString();
        }
    }
}
