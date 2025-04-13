using ProductCleanSample.Framwork.Application.Contracts;

namespace ProductCleanSample.Framework.Infrastructure.Services
{
    //Install Pakage --- > PM> NuGet\Install-Package Ulid -Version 1.3.4

    public class GuidGenerator : IIdGenerator<Guid>
    {
        // public Guid Next() => Guid.NewGuid();
        public Guid Next() => (Guid)Ulid.NewUlid();
    }
}
