using Microsoft.Extensions.Logging;
using ProductCleanSample.Framwork.Application.Contracts;

namespace ProductCleanSample.Framework.Infrastructure.Services
{
    
    public class EmailService(ILogger<EmailService> logger) : INotification
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public Task SendAsync(string message, string destination)
        {
            logger.LogInformation(
                "Message : {Message},Destination: {Destination}",
                message,
                destination);
            return Task.CompletedTask;
        }
    }
}
