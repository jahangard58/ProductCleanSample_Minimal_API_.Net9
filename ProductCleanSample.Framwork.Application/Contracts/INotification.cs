namespace ProductCleanSample.Framwork.Application.Contracts
{
    public interface INotification
    {
        Task SendAsync(string message,string destination);
    }
}
