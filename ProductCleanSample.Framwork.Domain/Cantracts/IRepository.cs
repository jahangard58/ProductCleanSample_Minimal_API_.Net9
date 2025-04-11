using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Domain.Cantracts
{
    //2
    public interface IRepository<TEntity, TId> 
           where TEntity : IEntity<TId>
           where TId : notnull
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id);
    }
}
