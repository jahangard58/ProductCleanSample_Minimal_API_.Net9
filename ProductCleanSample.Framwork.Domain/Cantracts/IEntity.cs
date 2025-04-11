using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Domain.Cantracts
{
    //1
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
