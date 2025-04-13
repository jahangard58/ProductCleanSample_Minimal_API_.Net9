using ProductCleanSample.Framwork.Domain.Cantracts;

namespace ProductCleanSample.Framwork.Domain
{
    public abstract class Entity<TId>: IEntity<TId>
        where TId : notnull
    {
        public TId Id { get;}
        protected Entity(TId id) => Id = id;
    }
}
