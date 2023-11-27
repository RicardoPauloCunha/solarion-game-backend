using FluentValidation;
using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using System.Net;

namespace SolarionGame.Api.Configurations.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ResultWrapper
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
               .Select(validator => validator.Validate(context))
               .SelectMany(result => result.Errors)
               .Where(error => error != null)
               .ToList();

            if (failures.Any())
            {
                var errors = failures
                    .GroupBy(error => error.PropertyName, (key, values) => values.Select(y => y.ErrorMessage))
                    .SelectMany(error => error)
                    .ToList();

                var result = ResultWrapper.GenerateMessage(
                    "Os dados enviados para a requisição são inválidos.",
                    HttpStatusCode.UnprocessableEntity,
                    errors) as TResponse;

                return await Task.FromResult(result);
            }

            return await next();
        }
    }
}
