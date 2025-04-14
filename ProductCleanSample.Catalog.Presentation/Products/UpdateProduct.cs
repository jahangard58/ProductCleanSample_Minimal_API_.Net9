using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ProductCleanSample.Catalog.Application.Products.Contracts;
using ProductCleanSample.Catalog.Application.Products.Contracts.Dtos;
using ProductCleanSample.Framwork.Persentation;
using ProductCleanSample.Framwork.Persentation.Extensions;

namespace ProductCleanSample.Catalog.Presentation.Products
{
    public static class UpdateProduct
    {
        public record UpdateProductRequest(string Name, decimal Price, string? Description);

        public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
        {
            public UpdateProductValidator()
            {
                RuleFor(m => m.Name)
                    .NotEmpty()
                    .WithMessage("نام اجباری است")
                    .MinimumLength(3)
                    .WithMessage("حداقل طول سه حرف می باشد");

                RuleFor(m => m.Price)
                    .NotEmpty()
                    .GreaterThan(0)
                    .WithMessage("قیمت نمی تواند مقدار منفی باشد");

                RuleFor(m => m.Description)
                    .MaximumLength(200)
                    .WithMessage("توضیحات نباید بیشتر از 200 حرف باشد");
            }
        }

        public record UpdateProductResponse(bool IsSuccess);

        public class UpdateProductEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder
                    .MapPut("/products/{productId}", UpdateProductHandler)
                    .Validate<UpdateProductRequest>()
                    .WithTags(EndpointSchema.ProductTag);
            }
        }

        public static async Task<IResult> UpdateProductHandler(
        [FromRoute] Guid productId,
        [FromBody] UpdateProductRequest request,
        [FromServices] IProductManager manager
    )
        {
            var dto = request.Adapt<UpdateProductDto>() with { ProductId = productId };

            var updateProductResult = await manager.UpdateProductAsync(dto);

            if (updateProductResult.IsSuccess)
                return TypedResults.Ok(new UpdateProductResponse(true));
            else
                return TypedResults.BadRequest(updateProductResult.Error);
        }

    }
}
