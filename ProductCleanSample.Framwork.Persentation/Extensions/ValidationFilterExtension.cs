using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ProductCleanSample.Framwork.Persentation.Extensions
{
    public static class ValidationFilterExtension
    {
        /// <summary>
        /// Adds a validation filter to the service collection.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static RouteHandlerBuilder Validate<TRequest>(this RouteHandlerBuilder builder)
        {
            builder.AddEndpointFilter<EndpointValidationFilter<TRequest>>();
            return builder;
        }
    }
}
