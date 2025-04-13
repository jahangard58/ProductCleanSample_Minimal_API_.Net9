using ProductCleanSample.Framwork.Domain.Cantracts;

namespace ProductCleanSample.Catalog.Domain.Products
{
    public interface IProductRepository : IRepository<Product, Guid> { }
   
}
