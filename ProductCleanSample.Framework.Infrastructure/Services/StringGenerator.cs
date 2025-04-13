using ProductCleanSample.Framwork.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framework.Infrastructure.Services
{
    public class StringGenerator : IIdGenerator<string>
    {
        public string Next() => Ulid.NewUlid().ToBase64();
        
    }
}
