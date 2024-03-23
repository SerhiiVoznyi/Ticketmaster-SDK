# Ticketmaster Open API Wrapper for .NET

[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/SerhiiVoznyi/ticketmaster-api-sdk-dot-net/blob/master/LICENSE.md)

## Legal notice

Code & Opinions expressed in this repository are solely my own and do not express the views or opinions of my employer.
This code is not supported by any employer as well as not profitable and do not bring any financial benefits. All work that was done during its creation was conducted in my spare/personal time and based only on my willingness to help the open-source community.

## About

The Ticketmaster Open API Wrapper contains projects with the implementation of easy access to API endpoints.
For more detailed information about the API and to get your API key head <a href="http://developer.ticketmaster.com/">here</a>.
This Open API Wrapper supports Discovery <a href="http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/">v2</a>.

## Important

Hi everyone, please, left a feedback about this project or about components.
It will help me to improve this library.
You can do this in any way you like:

- Send me email.
- Write to me in Skype.
- Contact me in Linkedin.

Details you can find in 'Authors' section below.

## Usage

## Installetion

[![NuGet](https://img.shields.io/badge/NuGet-v3.0.1-blue.svg)](https://www.nuget.org/packages/Ticketmaster.Discovery/)

You can install the last stable version of Ticketmaster.Discovery SDK using nuget.
For more details about package please visit [this](https://www.nuget.org/packages/Ticketmaster.Discovery/).

```
PM> Install-Package Ticketmaster.Discovery
```

### Simple usage of <code>EventsClient</code>

```C#
  var api = new DiscoveryApi("YOUR CLIENT API KEY");

  var searchRequest = new SearchEventsRequest().AddQueryParameter("size", 1);
  var searchResponse = await api.Events.Search(searchRequest);

  var getResponse = await api.Events.GetDetails(new GetRequest("Event Id"));
  var getImagesResponse = await api.Events.GetImages(new GetRequest("Event Id"));
```

The requests classes and **BaseQuery** class.

The <a href="http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/">Discovery API</a> can accept query parameters
for different endpoints. To allow pass this query parameters was created <code>BaseQuery</code> which have <code>QueryParameters</code> property. \*

For adding this parameters you just need create new instance of IDiscoveryApiRequest, IDiscoveryApiGetRequest interface. In this solution we have implementations for this interfaces. The <code>SearchAttractionsRequest</code>, <code>SearchClassificationsRequest</code>, <code>SearchEventsRequest</code>, <code>SearchVenuesRequest</code> classes. Use method <code> AddQueryParameter </code> to add query properties, the rules described in Method description for Api. The Example for <a href="http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/#srch-events-v2">Search Events</a> method is:

## Authors

- **Serhii Voznyi** - _Initial work_
  - [LinkedIn](https://www.linkedin.com/in/serhii-voznyi/)
  - <a href="mailto:serhiivoznyi@gmail.com?Subject=TicketmasterSDK" target="_top">serhiivoznyi@gmail.com</a>
  - Skype: serhiivoznyi

See also the list of [contributors](https://github.com/SerhiiVoznyi/ticketmaster-api-sdk-dot-net/graphs/contributors) who participated in this project.

## Our Team

- Durinf development process, please, follow [Code Of Conduct](CONTRIBUTING.md).

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
