namespace ProductCleanSample.Framwork.Application.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IIdGenerator<TId>
    {
        TId Next();
    }
}
