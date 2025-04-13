using ProductCleanSample.Framwork.Domain.Cantracts.Data;
using System.Linq.Expressions;

namespace ProductCleanSample.Framwork.Domain.Cantracts
{
    //2

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IRepository<TEntity, TId>
           where TEntity : IEntity<TId>
           where TId : notnull
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync2(TEntity entity); //استاد
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id);

        //? Internal Using (Domain)
        Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<PagedList<TEntity>> SearchAsync(SearchData data);
    }
}
