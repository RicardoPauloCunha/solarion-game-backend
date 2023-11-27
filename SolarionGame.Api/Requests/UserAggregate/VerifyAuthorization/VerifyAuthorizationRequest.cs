using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;
using System.Security.Claims;

namespace SolarionGame.Api.Requests.UserAggregate.VerifyAuthorization
{
    public class VerifyAuthorizationRequest : IRequest<ResultWrapper>
    {
        public ClaimsPrincipal Claims { get; private set; }
        public long UserId { get; private set; }
        public UserTypeEnum UserType { get; private set; }

        public VerifyAuthorizationRequest()
        {
            
        }

        public VerifyAuthorizationRequest(ClaimsPrincipal claims, long userId, UserTypeEnum userType)
        {
            Claims = claims;
            UserId = userId;
            UserType = userType;
        }
    }
}
