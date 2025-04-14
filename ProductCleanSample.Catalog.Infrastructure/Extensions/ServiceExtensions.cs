using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductCleanSample.Catalog.Domain.Products;
using ProductCleanSample.Catalog.Infrastructure.Data;
using ProductCleanSample.Catalog.Infrastructure.Products;
using ProductCleanSample.Framework.Infrastructure.Services;
using ProductCleanSample.Framwork.Application.Contracts;

namespace ProductCleanSample.Catalog.Infrastructure.Extensions
{
    public  static class ServiceExtensions
    {
        public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services,
                                                                        IConfiguration configuration )
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<INotification,EmailService>();
            services.AddScoped<IIdGenerator<Guid>,GuidGenerator>();
            services.AddScoped<IIdGenerator<string>,StringGenerator>();

            // services.AddDbContext<CatalogContext>(builder =>
            // {
            //     builder.UseSqlServer(configuration.GetConnectionString("Catalog"));
            // });
            services.AddDbContextPool<CatalogContext>(builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("Catalog"));
            });

            return services;
        }
    }
}
