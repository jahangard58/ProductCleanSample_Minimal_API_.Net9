using ProductCleanSample.Framwork.Domain.Cantracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Domain
{
    public abstract class Entity<TId>: IEntity<TId>
        where TId : notnull
    {
        public TId Id { get;}
        protected Entity(TId id) => Id = id;
    }
}
