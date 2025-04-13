using Microsoft.AspNetCore.Routing;
namespace ProductCleanSample.Framwork.Persentation
{
    // Install Pakege ---> PM> NuGet\Install-Package FluentValidation.DependencyInjectionExtensions -Version 11.11.0
    // Install Pakege ---> PM> NuGet\Install-Package Microsoft.AspNetCore.App -Version 2.2.8

    /// <summary>
    /// Interface for defining an endpoint in the application.
    /// </summary>
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder builder);
    }
}
