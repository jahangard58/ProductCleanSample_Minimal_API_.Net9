using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Application.Contracts
{
    public interface IIdGenerator<TId>
    {
        TId Next();
    }
}
