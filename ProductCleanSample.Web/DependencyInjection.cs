using Microsoft.AspNetCore.Builder;
using ProductCleanSample.Catalog.Infrastructure.Extensions;
using ProductCleanSample.Catalog.Presentation.Extensions;
using ProductCleanSample.Framwork.Persentation;
using ProductCleanSample.Framwork.Persentation.Extensions;
using Scalar.AspNetCore;

namespace ProductCleanSample.Web
{
    public static class DependencyInjection
    {
        // Install Pakage PM> NuGet\Install-Package Microsoft.AspNetCore.OpenApi -Version 9.0.4
        // Install Pakage PM> NuGet\Install-Package Microsoft.EntityFrameworkCore.Design -Version 9.0.4
        // Install Pakage PM> NuGet\Install-Package Scalar.AspNetCore -Version 2.1.13

        /// <summary>
        /// Add Services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(
                            this IServiceCollection services,
                            IConfiguration configuration)
        {
            //? Register Services
            services.AddOpenApi();
            services.AddCatalogPersentation();
            services.AddCatalogInfrastructure(configuration);
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            services.AddCors(setup=> 
            {
                setup.AddDefaultPolicy(policy =>
                {
                    //Environment Develop   USE  ==> any Allow
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();



                    //Environment Production   USE===>  With
                    // URL Front Application
                    //policy.WithOrigins("http://localhost:4536/").WithMethods("GET","POST","PUT");

                });
            });

            return services;
        }

        /// <summary>
        /// Use Middlewares
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseMiddlewaresAli(this WebApplication app)
        {
            app.UseExceptionHandler();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
                app.MapGet("/", () => Results.Redirect("/scalar")).WithTags("Root");
            }
            //else
            //{
            //    app.UseHsts();
            //}


            app.MapEndpoints();

            app.UseCors();

            return app;

        }
    }
}
