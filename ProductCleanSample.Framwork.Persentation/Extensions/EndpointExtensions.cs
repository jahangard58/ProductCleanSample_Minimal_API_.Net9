using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace ProductCleanSample.Framwork.Persentation.Extensions
{
    public static class EndpointExtensions
    {
        /// <summary>
        /// Add all endpoints in the assembly to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IServiceCollection AddEndpoints(
            this IServiceCollection services,
            Assembly assembly) 
        {
            var serviceDescriptors = assembly
            .GetTypes()
            .Where(t => t.IsClass && t.IsAssignableTo(typeof(IEndpoint)))
            .Select(endpointType => ServiceDescriptor.Transient(typeof(IEndpoint), endpointType));

            services.TryAddEnumerable(serviceDescriptors);

            return services;
        }

        /// <summary>
        /// Maps all endpoints in the service collection to the application builder.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            var endpoints = app.Services.GetServices<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                endpoint.MapEndpoint(app);
            }
            return app;
        }



    }
}
