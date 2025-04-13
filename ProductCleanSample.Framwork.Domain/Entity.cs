using ProductCleanSample.Framwork.Domain.Cantracts;

namespace ProductCleanSample.Framwork.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class Entity<TId>: IEntity<TId>
        where TId : notnull
    {
        public TId Id { get;}
        protected Entity(TId id) => Id = id;
    }
}
