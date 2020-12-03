# Ticketmaster.Discovery

This project contains clients for Second version **V2** of **Ticketmaster
[Discovery](http://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/)
API** with base models for response.

## Installetion
[![NuGet](https://img.shields.io/badge/NuGet-v2.0.4-blue.svg)](https://www.nuget.org/packages/Ticketmaster.Discovery/)

You can install the last stable version of Ticketmaster.Discovery SDK using nuget.
```
PM> Install-Package Ticketmaster.Discovery
```
For more details about package please visit [this](https://www.nuget.org/packages/Ticketmaster.Discovery/).

## How to use
### 1. Configure
Usage of any client require **<code>IClientConfig</code>** to be implemented
this interface is common fo all subclients clients in this library.

```C#
var config = new Config("Your API Key");
```

### 2. Create API client

This library supports various ways to instantiate your API client. But recommended one is by creating Discovery Api client and Configuration in configure method.
As it is shown in example below

```C#
var apiClient = new DiscoveryApi(config);
```

### 3. Build request

You can call any method from [DISCOVERY API](https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/) 
by building and executing appropriate requests to the API method.
For instance [Event Search](https://developer.ticketmaster.com/products-and-docs/apis/discovery-api/v2/#search-events-v2)
method.

```C#
using (var client = new DiscoveryApi(config))
{
    var request = new SearchEventsRequest()
        .AddQueryParameter(SearchEventsQueryParameters.source, "ticketmaster")
        .AddQueryParameter(SearchEventsQueryParameters.size, 20)
        .AddQueryParameter(SearchEventsQueryParameters.page, 0);

    var result = await client.Events.SearchEventsAsync(request);
}
```

The result will be returned as an object of type **SearchEventsResponse**
