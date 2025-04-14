using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using ProductCleanSample.Catalog.Application.Products.Contracts;
using ProductCleanSample.Catalog.Application.Products;
using ProductCleanSample.Framwork.Persentation.Extensions;

namespace ProductCleanSample.Catalog.Presentation.Extensions
{
    //Install Pakage PM> NuGet\Install-Package FluentValidation -Version 11.11.0
    //Install Pakage PM> NuGet\Microsoft.Extensions.DependencyInjection -Version 9.0.4
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCatalogPersentation(this IServiceCollection services)
        {
            var assembly=typeof(ServiceExtensions).Assembly;

            services.AddValidatorsFromAssembly(assembly);
            services.AddEndpoints(assembly);
            services.AddScoped<IProductManager, ProductManager>();

            return services;

        }
    }
}
