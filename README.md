[![](https://img.shields.io/nuget/v/soenneker.planetscale.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.planetscale.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.planetscale.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.planetscale.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.planetscale.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.planetscale.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.PlanetScale.HttpClients
### A thread-safe singleton HttpClient for PlanetScale's OpenAPI integration.

## Installation

```
dotnet add package Soenneker.PlanetScale.HttpClients
```

## Configuration and usage

Register `services.AddPlanetScaleOpenApiHttpClientAsSingleton()` from
`Soenneker.PlanetScale.HttpClients.Registrars` and inject
`IPlanetScaleOpenApiHttpClient` from `Soenneker.PlanetScale.HttpClients.Abstract`.
Call `await httpClientUtil.Get(cancellationToken)` to obtain the cached client.

Set `PlanetScale:ApiKey` to `<SERVICE_TOKEN_ID>:<SERVICE_TOKEN>` through your secret
store or the `PlanetScale__ApiKey` environment variable. Requests use the
`Authorization` header without a Bearer prefix for service tokens.

The default base address is `https://api.planetscale.com/v1/`, so relative paths
such as `organizations` retain the API version. Override `PlanetScale:ClientBaseUrl`
to use a different endpoint. For OAuth, set `PlanetScale:AuthHeaderValueTemplate`
to `Bearer {token}` and use the access token as `PlanetScale:ApiKey`.

The utility owns the cached HTTP client; do not dispose it per request.
