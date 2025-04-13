using ProductCleanSample.Framwork.Domain;

namespace ProductCleanSample.Catalog.Domain.Products
{
    public class Product : Entity<Guid>
    {
        public Product(Guid id) : base(id) { }

        // 'private set'   vaghti yek proprty darim ke ehtamalan Taghirat(Rename) dare
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public string? Description { get; set; }


        public static Result<Product> Create(
                                    Guid productId,
                                    string name,
                                    decimal price,
                                    string? description = default)
        {
            //? Guards
            //? Rules

            // ArgumentException.ThrowIfNullOrEmpty(name);
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Product>(
                    Error.Validation("Product:Create", "Name is a required")
                );
            }

            // var product = new Product(productId)
            // {
            //     Name = name,
            //     Price = price,
            //     Description = description,
            // };

            // return Result.Success(product);

            return new Product(productId)
            {
                Name = name,
                Price = price,
                Description = description,
            };
        }


        public void ChangeName(string name)
        {
            //? Can Execute
            //? Execute

            Name = name;

            //? Create Event
        }

        public void ChangePrice(decimal price)
        {
            Price = price;
        }

    }
}
