using Microsoft.AspNetCore.Authorization;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;

namespace SolarionGame.Api.Configurations.Auth.Requirement
{
    public class AuthorizationRequirement : IAuthorizationRequirement
    {
        public long UserId { get; private set; }
        public UserTypeEnum UserType { get; private set; }

        public AuthorizationRequirement(long userId, UserTypeEnum userType)
        {
            UserId = userId;
            UserType = userType;
        }
    }
}
