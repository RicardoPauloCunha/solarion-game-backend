using Microsoft.EntityFrameworkCore;
using SolarionGame.Infrastructure.Data;
using System.Reflection;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class EntityFrameworkStartup
    {
        public static void AddCustomEntityFramework(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<SolarionGameContext>(options =>
                options.UseMySql(
                    config.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection")),
                    mySqlOptionsAction: mySqlOption =>
                    {
                        mySqlOption.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        mySqlOption.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                    }
                )
            );
        }
    }
}
