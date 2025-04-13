namespace ProductCleanSample.Framwork.Domain.Cantracts
{
    //1

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
