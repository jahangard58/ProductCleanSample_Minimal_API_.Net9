namespace ProductCleanSample.Framwork.Domain.Cantracts
{
    //1
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
