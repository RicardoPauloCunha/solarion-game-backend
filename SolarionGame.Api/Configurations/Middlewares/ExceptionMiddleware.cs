using SolarionGame.Api.Configurations.Wrappers;
using System.Net;

namespace SolarionGame.Api.Configurations.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex.Errors.Select(x => x.ErrorMessage).ToList());
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex.Message);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string exceptionMessage)
        {
            List<string> errors = new() { exceptionMessage };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsJsonAsync(new ResultWrapper(
                "Ocorreu um erro na operação.",
                HttpStatusCode.InternalServerError,
                errors));
        }

        private static async Task HandleValidationExceptionAsync(HttpContext context, List<string> errors)
        {
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

            await context.Response.WriteAsJsonAsync(new ResultWrapper(
                "Ocorreu um erro na operação. Campos da entidade inválidos",
                HttpStatusCode.UnprocessableEntity,
                errors));
        }
    }
}
