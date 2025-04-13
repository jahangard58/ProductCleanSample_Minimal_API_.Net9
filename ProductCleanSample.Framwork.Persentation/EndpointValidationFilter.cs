using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProductCleanSample.Framwork.Persentation
{
    /// <summary>
    /// Endpoint validation filter for validating requests using FluentValidation.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <param name="validator"></param>
    public class EndpointValidationFilter<TRequest>(IValidator<TRequest> validator) : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(
            EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var request = context.Arguments.FirstOrDefault(argument=> argument is TRequest);
            if (request is not null)
            {
                var validationResult = await validator.ValidateAsync((TRequest)request);
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                    
                } 
            }
            return await next.Invoke(context);
        }
    }


}
