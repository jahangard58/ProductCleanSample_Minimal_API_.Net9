using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Domain
{
    public enum ErrorType
    {
        Failure = 1,
        Validation,
        Problem,
        NotFound,
        Conflict,
    }
}
