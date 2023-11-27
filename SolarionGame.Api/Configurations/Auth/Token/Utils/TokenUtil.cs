using SolarionGame.Api.Configurations.Auth.Token.Enums;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;
using System.Security.Claims;

namespace SolarionGame.Api.Configurations.Auth.Token.Utils
{
    public class TokenUtil
    {
        public static long GetUserId(ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypeEnum.UserId);

            if (claim == null)
                return 0;

            return Convert.ToInt64(claim.Value);
        }

        public static UserTypeEnum GetUserType(ClaimsPrincipal user)
        {
            var claim = user.Claims.FirstOrDefault(x => x.Type == ClaimTypeEnum.UserType);

            if (claim == null)
                return UserTypeEnum.None;

            if (int.TryParse(claim.Value, out int cast))
                return (UserTypeEnum)cast;
            else
                return UserTypeEnum.None;
        }
    }
}
