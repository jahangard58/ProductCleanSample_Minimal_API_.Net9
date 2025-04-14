using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCleanSample.Catalog.Domain.Products;

namespace ProductCleanSample.Catalog.Infrastructure.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(m => m.Id);
            builder.Property(m=> m.Id).ValueGeneratedNever();
            builder.Property(m=> m.Name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(m=> m.Price).IsRequired().IsUnicode().HasPrecision(10,3);
            builder.Property(m => m.Description).IsRequired(false).IsUnicode().HasMaxLength(250);
        }
    }
}
