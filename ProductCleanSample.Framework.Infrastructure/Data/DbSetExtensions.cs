using Microsoft.EntityFrameworkCore;
using ProductCleanSample.Framwork.Domain.Cantracts.Data;
using System.Linq.Dynamic.Core;

namespace ProductCleanSample.Framework.Infrastructure.Data
{
    // CLI Trminal=> dotnet add package Microsoft.EntityFrameworkCore --version 9.4
    ////PM> NuGet\Install-Package Microsoft.EntityFrameworkCore -Version 9.4
    // PM> dotnet dev-certs https --trust
    // Install Pakage   ---> Microsoft.EntityFrameworkCore 9.4
    // Install Pakage---> Microsoft.Extensions.Logging 9.4
    // PM> NuGet\Install-Package Microsoft.EntityFrameworkCore.DynamicLinq -Version 9.6.0.2   
    public static class DbSetExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> query, string? sort)
        {
            if (string.IsNullOrEmpty(sort))
                return query;

            //? Price asc --> Orderby(p=> p.Price)
            //? Price desc --> OrderbyDescending(p=> p.Price)
            //? string -> Linq
            return query.OrderBy(sort);

        }
        // public static async Task<IReadOnlyList<TEntity>> PaginateAsync<TEntity>(
        //     this IQueryable<TEntity> query,
        //     int pageSize,
        //     int pageIndex
        // )
        // {
        //     var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        //     return result;
        // }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public static async Task<PagedList<TEntity>> PaginateAsync<TEntity>(
        this IQueryable<TEntity> query,
        int pageSize,
        int pageIndex
        )
        {
            var entities = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var totalRecordCount = await query.CountAsync();

            return new PagedList<TEntity>(entities, totalRecordCount);
        }
    }
}
