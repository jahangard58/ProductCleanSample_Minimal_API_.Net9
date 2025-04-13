namespace ProductCleanSample.Catalog.Application.Products.Contracts.Dtos
{
    public record SearchProductsDto(string? SearchText, string? Sort, int PageSize, int PageIndex);

}
