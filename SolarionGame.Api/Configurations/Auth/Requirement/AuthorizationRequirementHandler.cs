using Microsoft.AspNetCore.Authorization;
using SolarionGame.Api.Configurations.Auth.Token.Utils;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;

namespace SolarionGame.Api.Configurations.Auth.Requirement
{
    public class AuthorizationRequirementHandler : AuthorizationHandler<AuthorizationRequirement, long>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement, long resource)
        {
            #region Validações
            if (requirement == null)
            {
                context.Fail();
                return Task.CompletedTask;
            };
            #endregion

            #region Tipo usuário
            UserTypeEnum userType = TokenUtil.GetUserType(context.User);

            if (userType != requirement.UserType)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            #endregion

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
