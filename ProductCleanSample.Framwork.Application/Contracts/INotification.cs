namespace ProductCleanSample.Framwork.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface INotification
    {
        Task SendAsync(string message,string destination);
    }
}
