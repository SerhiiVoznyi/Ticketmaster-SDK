# Ticketmaster Open API Wrapper for .NET 

[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/SerhiiVoznyi/ticketmaster-api-sdk-dot-net/blob/master/LICENSE.md)

# Legal notice
<p>
Code & Opinions expressed are solely my own and do not express the views or opinions of my employer. This code is not supported by employer
</p>

<p>
The Ticketmaster Open API Wrapper contains projects with the implementation of easy access to API endpoints. 
For more detailed information about the API and to get your API key head <a href="http://developer.ticketmaster.com/">here</a>. 
This Open API Wrapper supports Discovery <a href="http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/">v2</a>.
</p>


## Important

Hi everyone, please, left a feedback about this project or about components.
It will help me to improve this library.
You can do this in any way you like:
* Send me email.
* Write to me in Skype.
* Contact me in Linkedin.

Details you can find in 'Authors' section below.

## Overview
The solution contains different projects

- [Ticketmaster.Core](https://github.com/SerhiiVoznyi/Ticketmaster-SDK/tree/master/src/Ticketmaster.Core)
- [Ticketmaster.Discovery](https://github.com/SerhiiVoznyi/Ticketmaster-SDK/tree/master/src/Ticketmaster.Discovery)

## Usage

### Setup IClientConfig
The implementation of interfaces, the clients, in sdk required to resolve <code>ClientConfig</code> and pass them like a parameter into constructor. It have <code>ConsumerKey</code> property what is the Consumer Key for ticketmaster api. And <code>ApiRootUrl</code> what should be <code>https://app.ticketmaster.com/discovery/</code>.

```C#
    public interface IClientConfig
    {
        string ConsumerKey { get; }
        string ApiRootUrl { get; }
    }
```
<h3>Simple usage of <code>EventsClient</code></h3>

```C#
  var config = Substitute.For<IClientConfig>();
  config.ConsumerKey.Returns("K1uJLzJ5mdt3oBKNSzjcEEEzxHuJJXiX-1");
  config.ApiRootUrl.Returns("https://app.ticketmaster.com/discovery/");

  var restClient = new RestClient(config.ApiRootUrl);

  var eventsApiClient = new EventsClient(client, config);
  var result = await _sut.SearchEventsAsync(new SearchEventsRequest());
````

<h3>The requests classes and <code>BaseQuery</code> class.</h3>

The <a href="http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/">Discovery API</a> can accept query parameters
for different endpoints. To allow pass this query parameters was created <code>BaseQuery</code> which have <code>QueryParameters</code> property. 

For adding this parameters you just need create new instance of IDiscoveryApiRequest, IDiscoveryApiGetRequest interface. In this solution we have implementations for this interfaces. The <code>SearchAttractionsRequest</code>, <code>SearchClassificationsRequest</code>, <code>SearchEventsRequest</code>, <code>SearchVenuesRequest</code> classes. Use method <code> AddQueryParameter </code> to add query properties, the rules described in Method description for Api. The Example for <a href="http://developer.ticketmaster.com/products-and-docs/apis/discovery/v2/#srch-events-v2">Search Events</a> method is: 

```C#
var request = new SearchAttractionsRequest();
request.AddQueryParameter(QueryParameters paremeter, string value);
```
## Authors
* **Serhii Voznyi** - *Initial work*
  - [LinkedIn](https://www.linkedin.com/in/serhii-voznyi/)
  - <a href="mailto:serhiivoznyi@gmail.com?Subject=TicketmasterSDK" target="_top">serhiivoznyi@gmail.com</a>
  - Skype: serhiivoznyi

See also the list of [contributors](https://github.com/SerhiiVoznyi/ticketmaster-api-sdk-dot-net/graphs/contributors) who participated in this project.

## Our Team
 * Durinf development process, please, follow [Code Of Conduct](CONTRIBUTING.md).

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
