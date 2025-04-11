using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Domain.Cantracts.Data
{
    public record SearchData(string? SearchText,string? Sort,int? PageSize,int? PageIndex);
    
}
