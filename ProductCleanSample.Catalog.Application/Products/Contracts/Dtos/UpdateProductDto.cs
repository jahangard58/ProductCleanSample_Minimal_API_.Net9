namespace ProductCleanSample.Catalog.Application.Products.Contracts.Dtos
{
    public record UpdateProductDto(Guid ProductId, string Name, decimal Price, string Description);

}
