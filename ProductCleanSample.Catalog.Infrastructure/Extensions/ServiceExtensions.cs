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
        /// <summary>
        /// *Default project: ProductCleanSample.Catalog.Infrastructure*
        /// PM> dotnet tool update --global dotnet-ef
        /// PM> dotnet --version
        /// PM> dotnet ef --version   //version ef tool Cli
        /// PM> dotnet ef dbcontext list -s ProductCleanSample.Web   //list Context ha ra namayesh midahad
        /// PM> dotnet ef Migrations add InitRun -s ProductCleanSample.Web     // -s yani stratUp Project set mishavad
        /// PM> dotnet ef database update -s ProductCleanSample.Web           
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
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
                builder.UseSqlServer(configuration.GetConnectionString("Catalog"),
                    x => x.MigrationsAssembly("ProductCleanSample.Web"));
              
            });

            return services;
        }
    }
}
