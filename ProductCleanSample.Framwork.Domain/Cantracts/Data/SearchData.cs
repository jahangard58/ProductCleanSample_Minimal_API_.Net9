namespace ProductCleanSample.Framwork.Domain.Cantracts.Data
{
    /// <summary>
    /// SearchData
    /// </summary>
    /// <param name="SearchText"></param>
    /// <param name="Sort"></param>
    /// <param name="PageSize"></param>
    /// <param name="PageIndex"></param>
    public record SearchData(string? SearchText,string? Sort,int PageSize,int PageIndex);
    
}
