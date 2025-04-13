using ProductCleanSample.Framwork.Application.Contracts;

namespace ProductCleanSample.Framework.Infrastructure.Services
{
    public class StringGenerator : IIdGenerator<string>
    {
        
        public string Next() => Ulid.NewUlid().ToBase64();
        
    }
}
