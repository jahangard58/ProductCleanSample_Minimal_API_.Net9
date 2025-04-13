namespace ProductCleanSample.Framwork.Domain.Cantracts.Data
{
    public class PagedList<TEntity>(IEnumerable<TEntity> entities,int totalRecordCount)
    {
        public IReadOnlyList<TEntity> Entities => entities.ToList().AsReadOnly();

        public int TotalRecordCount => totalRecordCount;
    }
}
