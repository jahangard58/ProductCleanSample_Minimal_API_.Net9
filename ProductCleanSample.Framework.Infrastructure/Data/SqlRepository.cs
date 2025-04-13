using Microsoft.EntityFrameworkCore;
using ProductCleanSample.Framwork.Domain;
using ProductCleanSample.Framwork.Domain.Cantracts;
using ProductCleanSample.Framwork.Domain.Cantracts.Data;
using System.Linq.Expressions;

namespace ProductCleanSample.Framework.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public abstract class SqlRepository<TEntity,TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : notnull
    {
        private readonly DbContext context;
        protected readonly DbSet<TEntity> entities;

        
        protected SqlRepository(DbContext dbContext)
        {
            this.context = dbContext;
            this.entities = dbContext.Set<TEntity>();   
        }

        public async Task InsertAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            entities.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }


        //? Public Search (Reflection)
        public Task<PagedList<TEntity>> SearchAsync(SearchData data)
        {
            //? DRY  تکرار نکن
            return Search(entities.AsNoTracking(), data.SearchText)
                .Sort(data.Sort)
                .PaginateAsync(data.PageSize, data.PageIndex);
        }
        protected abstract IQueryable<TEntity> Search(IQueryable<TEntity> query, string? searchText);


        public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await entities.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            var entity = await entities.FindAsync(id);

            return entity;
        }

        
    }

}
