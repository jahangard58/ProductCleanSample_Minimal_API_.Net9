using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProductCleanSample.Catalog.Application.Products.Contracts;
using ProductCleanSample.Catalog.Application.Products.Contracts.Dtos;
using ProductCleanSample.Framwork.Domain.Cantracts.Data;
using ProductCleanSample.Framwork.Persentation;
using ProductCleanSample.Framwork.Persentation.Extensions;

namespace ProductCleanSample.Catalog.Presentation.Products
{
    public static class SearchProduct
    {
        public record SearchProductRequest(
            string? SearchText,
            string? Sort,
            int? PageSize=10,
            int? PageIndex=1
            );

        
        public class SearchProductValidator : AbstractValidator<SearchProductRequest>
        {
            public SearchProductValidator()
            {
                RuleFor(m => m.PageSize).NotEmpty().LessThanOrEqualTo(50);

                RuleFor(m => m.PageIndex).NotEmpty().GreaterThanOrEqualTo(1);
            }
        }


        public record SearchProductResponse(PagedList<ProductDto> Products);

        public class SearchProductEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder
                    .MapGet("/products/search", SearchProductHandler)
                    .Validate<SearchProductRequest>()
                    .WithTags(EndpointSchema.ProductTag);
            }
        }

        public static async Task<IResult> SearchProductHandler(
        [AsParameters] SearchProductRequest request,
        [FromServices] IProductManager manager
    )
        {
            var dto = request.Adapt<SearchProductsDto>();

            var searchProductResult = await manager.SearchProductsAsync(dto);

            if (searchProductResult.IsSuccess)
                return TypedResults.Ok(new SearchProductResponse(searchProductResult.Value));
            else
                return TypedResults.BadRequest(searchProductResult.Error);
        }
    }
}
