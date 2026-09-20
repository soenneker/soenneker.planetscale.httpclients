using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.PlanetScale.HttpClients.Abstract;
using Soenneker.PlanetScale.HttpClients.Registrars;

namespace Soenneker.PlanetScale.HttpClients.Tests;

public sealed class PlanetScaleOpenApiHttpClientTests
{
    [Test]
    public async Task Preserves_version_path_and_service_token_and_caches_client()
    {
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["PlanetScale:ApiKey"] = "test-id:test-token"
        }).Build();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton(configuration);
        services.AddPlanetScaleOpenApiHttpClientAsSingleton();
        await using var provider = services.BuildServiceProvider();
        var utility = provider.GetRequiredService<IPlanetScaleOpenApiHttpClient>();

        var client = await utility.Get();
        await Assert.That(ReferenceEquals(client, await utility.Get())).IsTrue();
        await Assert.That(new Uri(client.BaseAddress!, "organizations").AbsoluteUri).IsEqualTo("https://api.planetscale.com/v1/organizations");
        await Assert.That(client.DefaultRequestHeaders.GetValues("Authorization").Single()).IsEqualTo("test-id:test-token");
    }
}
