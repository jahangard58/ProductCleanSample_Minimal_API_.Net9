namespace ProductCleanSample.Framwork.Domain.Cantracts.Data
{
    /// <summary>
    /// PageList
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entities"></param>
    /// <param name="totalRecordCount"></param>
    public class PagedList<TEntity>(IEnumerable<TEntity> entities,int totalRecordCount)
    {
        public IReadOnlyList<TEntity> Entities => entities.ToList().AsReadOnly();

        public int TotalRecordCount => totalRecordCount;
    }
}
