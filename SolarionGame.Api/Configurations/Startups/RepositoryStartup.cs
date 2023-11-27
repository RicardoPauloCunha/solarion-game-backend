using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Repositories;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Repositories;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;
using SolarionGame.Domain.SeedWork;
using SolarionGame.Infrastructure.Data;
using SolarionGame.Infrastructure.Data.PasswordRecoveryAggregate.Repositories;
using SolarionGame.Infrastructure.Data.ScoreAggregate.Repositories;
using SolarionGame.Infrastructure.Data.UserAggregate.Repositories;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class RepositoryStartup
    {
        public static void AddCustomRepository(this IServiceCollection services)
        {
            services.AddScoped<IPasswordRecoveryRepository, PasswordRecoveryRepository>();

            services.AddScoped<IDecisionRepository, DecisionRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRepository, Repository>();
        }
    }
}
