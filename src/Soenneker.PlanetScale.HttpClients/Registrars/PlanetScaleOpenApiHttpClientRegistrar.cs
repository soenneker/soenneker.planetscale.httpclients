using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.PlanetScale.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.PlanetScale.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class PlanetScaleOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="PlanetScaleOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPlanetScaleOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IPlanetScaleOpenApiHttpClient, PlanetScaleOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PlanetScaleOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPlanetScaleOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IPlanetScaleOpenApiHttpClient, PlanetScaleOpenApiHttpClient>();

        return services;
    }
}
