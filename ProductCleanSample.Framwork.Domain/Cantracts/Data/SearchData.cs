namespace ProductCleanSample.Framwork.Domain.Cantracts.Data
{
    public record SearchData(string? SearchText,string? Sort,int PageSize,int PageIndex);
    
}
