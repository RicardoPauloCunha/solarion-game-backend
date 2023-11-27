using MediatR;
using Microsoft.AspNetCore.Mvc;
using SolarionGame.Api.Configurations.Behaviors;

namespace SolarionGame.Api.Configurations.Startups
{
    public static class BehaviorStartup
    {
        public static void AddCustomBehavior(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                    new UnprocessableEntityObjectResult(actionContext.ModelState);
            });
        }
    }
}
