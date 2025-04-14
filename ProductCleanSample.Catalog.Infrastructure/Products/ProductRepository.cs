using Microsoft.EntityFrameworkCore;
using ProductCleanSample.Catalog.Domain.Products;
using ProductCleanSample.Catalog.Infrastructure.Data;
using ProductCleanSample.Framework.Infrastructure.Data;

namespace ProductCleanSample.Catalog.Infrastructure.Products
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    internal class ProductRepository(CatalogContext context) : SqlRepository<Product, Guid>(context),
                                                               IProductRepository
    {

        // public override async Task<IReadOnlyList<Product>> SearchAsync(SearchData data)
        // {
        //     //? Search
        //     //? Sort
        //     //? Pagination

        //     // var query = entities.AsNoTracking();

        //     // if (!string.IsNullOrEmpty(data.SearchText))
        //     // {
        //     //     query = query.Where(product =>
        //     //         EF.Functions.Like(product.Name, $"%{data.SearchText}%")
        //     //         || EF.Functions.Like(product.Description, $"%{data.SearchText}%")
        //     //     );
        //     // }

        //     // if (!string.IsNullOrEmpty(data.Sort))
        //     // {
        //     //     query = query.Sort(data.Sort);
        //     // }

        //     // query = query.Skip((data.PageIndex - 1) * data.PageSize).Take(data.PageSize);

        //     // return await query.ToListAsync();

        //     return await Search(entities.AsNoTracking(), data.SearchText)
        //         .Sort(data.Sort)
        //         .PaginateAsync(data.PageSize, data.PageIndex);
        // }


        protected override IQueryable<Product> Search(IQueryable<Product> query, string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return query;

            return query.Where(product =>
                   EF.Functions.Like(product.Name, $"%{searchText}%")
                || EF.Functions.Like(product.Description, $"%{searchText}%")
            );
        }
    }
}
