namespace ProductCleanSample.Catalog.Application.Products.Contracts.Dtos
{
    public record GetProductDto(Guid ProductId, string Name, decimal Price, string Description);

}
