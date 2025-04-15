using Microsoft.EntityFrameworkCore;
using ProductCleanSample.Catalog.Domain.Products;
using ProductCleanSample.Catalog.Infrastructure.Products;

namespace ProductCleanSample.Catalog.Infrastructure.Data
{
    //Install Pakage ---> PM> NuGet\Install-Package Microsoft.EntityFrameworkCore.Design -Version 9.0.4
    //Install Pakage ---> PM> NuGet\Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 9.0.4
    //Install Tool ----> PM> dotnet tool update --global dotnet-ef
    // 'Version .Net' ----> PM> dotnet --version
    // 'Version EFTools' ----> PM> dotnet ef --version


    /// <summary>
    /// 
    /// </summary>
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            // modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }

        public DbSet<Product> Products => Set<Product>();
        // public DbSet<Group> Groups => Set<Groups>();
    }
}
