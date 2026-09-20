using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.PlanetScale.HttpClients.Abstract;

/// <summary>
/// Provides a cached HTTP client for the PlanetScale API.
/// </summary>
public interface IPlanetScaleOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the HTTP client configured with PlanetScale:ClientBaseUrl and PlanetScale:ApiKey.
    /// The API key must contain the service token ID and token separated by a colon.
    /// </summary>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
