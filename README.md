# 🎟️ Ticketmaster Open API Wrapper for .NET

[![License](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/SerhiiVoznyi/ticketmaster-api-sdk-dot-net/blob/master/LICENSE.md)  
[![NuGet](https://img.shields.io/badge/NuGet-v3.0.2-blue.svg)](https://www.nuget.org/packages/Ticketmaster.Discovery/)

---

## ⚖️ Legal Notice

All code and opinions expressed in this repository are solely my own and do not represent the views or opinions of my employer.  
This project is not sponsored, endorsed, or financially supported by any organization. All work was done in my personal time to contribute to the open-source community.

---

## 📘 Overview

The **Ticketmaster Open API Wrapper for .NET** provides a simple and intuitive interface for accessing the Ticketmaster Open API endpoints.

This SDK currently supports the **[Discovery API v2](http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/)**.

For detailed API documentation or to obtain an API key, visit the [Ticketmaster Developer Portal](http://developer.ticketmaster.com/).

---

## ⚙️ Installation

Install the latest stable version from [NuGet](https://www.nuget.org/packages/Ticketmaster.Discovery/):

```bash
PM> Install-Package Ticketmaster.Discovery
```

---

## 🚀 Usage Example

Here’s a simple example using the `EventsClient`:

```csharp
var api = new DiscoveryApi("YOUR_CLIENT_API_KEY");

var searchRequest = new SearchEventsRequest().AddQueryParameter("size", 1);
var searchResponse = await api.Events.Search(searchRequest);

var getResponse = await api.Events.GetDetails(new GetRequest("EventId"));
var getImagesResponse = await api.Events.GetImages(new GetRequest("EventId"));
```

---

## 🧩 Query Parameters

The `BaseQuery` class and related request classes make it easy to work with query parameters supported by the [Discovery API](http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/).

To add query parameters, create an instance of one of the provided request classes implementing `IDiscoveryApiRequest` or `IDiscoveryApiGetRequest`.  
For example:

- `SearchEventsRequest`
- `SearchAttractionsRequest`
- `SearchClassificationsRequest`
- `SearchVenuesRequest`

Use the `AddQueryParameter` method to append parameters according to the API specification.  
Example (based on the [Search Events API](http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/#srch-events-v2)):

```csharp
var request = new SearchEventsRequest()
    .AddQueryParameter("keyword", "rock")
    .AddQueryParameter("city", "Los Angeles");
```

---

## 👥 Authors

- **Serhii Voznyi** – _Creator and Maintainer_
  - [LinkedIn](https://www.linkedin.com/in/serhii-voznyi/)
  - [Email](mailto:serhiivoznyi@gmail.com?Subject=TicketmasterSDK)
  - Skype: `serhiivoznyi`

See the list of [contributors](https://github.com/SerhiiVoznyi/ticketmaster-api-sdk-dot-net/graphs/contributors) who have participated in this project.

---

## 🤝 Contributing

Before contributing, please review the [Code of Conduct](CONTRIBUTING.md).

---

## 📄 License

This project is licensed under the **MIT License**.  
See the [LICENSE.md](LICENSE.md) file for details.
