using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCleanSample.Framwork.Application.Contracts
{
    public interface INotification
    {
        Task SendAsync(string message,string destination);
    }
}
