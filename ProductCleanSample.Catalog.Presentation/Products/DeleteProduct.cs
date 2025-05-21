using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProductCleanSample.Catalog.Application.Products.Contracts.Dtos;
using ProductCleanSample.Catalog.Application.Products.Contracts;
using ProductCleanSample.Framwork.Persentation;
using ProductCleanSample.Framwork.Persentation.Extensions;
using Mapster;

namespace ProductCleanSample.Catalog.Presentation.Products
{
    public class DeleteProduct
    {
        public record DeleteProductRequest(Guid ProductId, string Name, decimal Price);

        public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
        {
            public DeleteProductValidator()
            {
                RuleFor(m => m.ProductId)
                    .NotNull()
                    .WithMessage("! کالا یافت نشد");

            }
        }

        public record DeleteProductResponse(bool IsSuccess);

        public class DeleteProductEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder
                    .MapDelete("/products/{productId}", DeleteProductHandler)
                    .Validate<DeleteProductRequest>()
                    .WithTags(EndpointSchema.ProductTag);
            }
        }

        public static async Task<IResult> DeleteProductHandler(
                                            [FromRoute] Guid productId,
                                            [FromBody] DeleteProductRequest request,
                                            [FromServices] IProductManager manager)
        {
            var dto = request.Adapt<ProductDto>() with { Id = productId };

            var deleteProductResult = await manager.DeleteProductAsync2(dto);

            if (deleteProductResult.IsSuccess)
                return TypedResults.Ok(new DeleteProductResponse(true));
            else
                return TypedResults.BadRequest(deleteProductResult.Error);
        }

    }
}
