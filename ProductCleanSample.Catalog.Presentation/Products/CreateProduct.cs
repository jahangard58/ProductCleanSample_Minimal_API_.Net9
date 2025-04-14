using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using ProductCleanSample.Catalog.Application.Products.Contracts.Dtos;
using ProductCleanSample.Catalog.Application.Products.Contracts;
using ProductCleanSample.Framwork.Persentation;
using ProductCleanSample.Framwork.Persentation.Extensions;


namespace ProductCleanSample.Catalog.Presentation.Products
{
    public static class CreateProduct
    {
        public record CreateProductRequest(string Name, decimal Price, string? Description);

        public class CreateProductValidator : AbstractValidator<CreateProductRequest>
        {
            public CreateProductValidator()
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

        public record CreateProductResponse(Guid ProductId);

        public class CreateProductEndpoint : IEndpoint
        {
            public void MapEndpoint(IEndpointRouteBuilder builder)
            {
                builder
                    .MapPost("/products", CreateProductHandler)
                    .Validate<CreateProductRequest>()
                    .WithTags(EndpointSchema.ProductTag);
            }
        }

        public static async Task<IResult> CreateProductHandler(
        [FromBody] CreateProductRequest request,
        [FromServices] IProductManager manager
    )
        {
            var dto = request.Adapt<CreateProductDto>();

            var createProductResult = await manager.CreateProductAsync(dto);

            if (createProductResult.IsSuccess)
                return TypedResults.Ok(new CreateProductResponse(createProductResult.Value));
            else
                return TypedResults.BadRequest(createProductResult.Error);
        }
    }
}
