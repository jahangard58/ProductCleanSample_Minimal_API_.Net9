namespace ProductCleanSample.Framwork.Application.Contracts
{
    public interface IIdGenerator<TId>
    {
        TId Next();
    }
}
