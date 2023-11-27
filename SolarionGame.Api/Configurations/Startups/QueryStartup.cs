using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Queries;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Queries;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Queries;
using SolarionGame.Infrastructure.Data.PasswordRecoveryAggregate.Queries;
using SolarionGame.Infrastructure.Data.ScoreAggregate.Queries;
using SolarionGame.Infrastructure.Data.UserAggregate.Queries;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class QueryStartup
    {
        public static void AddCustomQuery(this IServiceCollection services)
        {
            services.AddScoped<IPasswordRecoveryQuery, PasswordRecoveryQuery>();

            services.AddScoped<IDecisionQuery, DecisionQuery>();
            services.AddScoped<IScoreQuery, ScoreQuery>();

            services.AddScoped<IUserQuery, UserQuery>();
        }
    }
}
