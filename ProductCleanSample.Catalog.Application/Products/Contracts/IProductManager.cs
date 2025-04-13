using ProductCleanSample.Catalog.Application.Products.Contracts.Dtos;
using ProductCleanSample.Framwork.Domain;
using ProductCleanSample.Framwork.Domain.Cantracts.Data;

namespace ProductCleanSample.Catalog.Application.Products.Contracts
{
    public interface IProductManager
    {
        Task<Result<Guid>> CreateProductAsync(CreateProductDto dto);
        Task<Result> UpdateProductAsync(UpdateProductDto dto);
        Task<Result> DeleteProductAsync(ProductDto dto);
        Task<Result> DeleteProductAsync2(ProductDto dto);
        Task<Result<GetProductDto>> GetProductByIdAsync(Guid productId);
        Task<Result<PagedList<ProductDto>>> SearchProductsAsync(SearchProductsDto dto);
    }
}
