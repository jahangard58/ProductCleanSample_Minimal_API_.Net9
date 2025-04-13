using ProductCleanSample.Catalog.Application.Products.Contracts;
using ProductCleanSample.Catalog.Application.Products.Contracts.Dtos;
using ProductCleanSample.Catalog.Domain.Products;
using ProductCleanSample.Framwork.Application.Contracts;
using ProductCleanSample.Framwork.Domain;
using ProductCleanSample.Framwork.Domain.Cantracts.Data;
using Mapster;

namespace ProductCleanSample.Catalog.Application.Products
{
    // Install Pakage ==> PM> NuGet\Install-Package Mapster -Version 7.4.0
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productRepository"></param>
    /// <param name="notification"></param>
    /// <param name="idGenerator"></param>
    public class ProductManager(
                                IProductRepository productRepository,
                                INotification notification,
                                IIdGenerator<Guid> idGenerator
                            ) : IProductManager
    {

        public async Task<Result<Guid>> CreateProductAsync(CreateProductDto dto)
        {
            var productId = idGenerator.Next();

            var createResult = Product.Create(productId, dto.Name, dto.Price, dto.Description);
            if (createResult.IsFailure)
                return Result.Failure<Guid>(createResult.Error);

            await productRepository.InsertAsync(createResult.Value);

            await notification.SendAsync($"Product with id {productId} created", "jahangard58@gmail.com");

            return productId;
        }

        public async Task<Result> DeleteProductAsync(ProductDto dto)
        {
            //throw new NotImplementedException();
            var product = await productRepository.GetByIdAsync(dto.ProductId);
            if (product is null)
            {
                Result.Failure<GetProductDto>(
                    Error.NotFound(
                        "ProductManager:DeleteProductAsync",
                        $"Product with identifier {dto.ProductId} not found"
                    )
                );
            }
            var strProductName = dto.Name;
            await productRepository.DeleteAsync(product);
            await notification.SendAsync($"Product with ProductName {strProductName} Deleted", "jahangard58@gmail.com");
            return Result.Success();

        }

        public async Task<Result> DeleteProductAsync2(ProductDto dto)
        {
            //throw new NotImplementedException();
            var product = await productRepository.GetByIdAsync(dto.ProductId);
            if (product is null)
            {
                Result.Failure<GetProductDto>(
                    Error.NotFound(
                        "ProductManager:DeleteProductAsync2",
                        $"Product with identifier {dto.ProductId} not found"
                    )
                );
            }
            var strProductName = dto.Name;
            await productRepository.DeleteAsync2(product);
            await notification.SendAsync($"Product with Name {strProductName} Deleted", "jahangard58@gmail.com");
            return Result.Success();

        }

        public async Task<Result<GetProductDto>> GetProductByIdAsync(Guid productId)
        {
            var product = await productRepository.GetByIdAsync(productId);
            if (product is null)
            {
                Result.Failure<GetProductDto>(
                    Error.NotFound(
                        "ProductManager:GetProductByIdAsync",
                        $"Product with identifier {productId} not found"
                    )
                );
            }

            return product.Adapt<GetProductDto>();
        }

        public async Task<Result<PagedList<ProductDto>>> SearchProductsAsync(SearchProductsDto dto)
        {
            var pagedProducts = await productRepository.SearchAsync(dto.Adapt<SearchData>());

            return new PagedList<ProductDto>(
                pagedProducts.Entities.Adapt<IReadOnlyList<ProductDto>>(),
                pagedProducts.TotalRecordCount
            );
        }

        public async Task<Result> UpdateProductAsync(UpdateProductDto dto)
        {
            var product = await productRepository.GetByIdAsync(dto.ProductId);
            if (product is null)
            {
                return Result.Failure(
                    Error.NotFound(
                        "ProductManager:UpdateProductAsync",
                        $"Product with identifier {dto.ProductId} not found"
                    )
                );
            }

            product.ChangeName(dto.Name);
            product.ChangePrice(dto.Price);
            product.Description = dto.Description;

            await productRepository.UpdateAsync(product);

            return Result.Success();
        }
    }
}
