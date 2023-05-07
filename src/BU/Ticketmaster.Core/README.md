# Ticketmaster.Core

This package contains common components for Ticketmaster SDK's
___
### Description
The Ticketmaster.Core solution contains components such ass common client interfaces:
* __IClientConfig__ - interface for client configuration;
* __IApiRequest__ - interface for api requests classes;
* __IApiGetRequest__ - interface inherited from IApiRequest created for api GET requests classes;
* __IApiResponse__ - interface for Api responses;

Base Implementation for Api Clients __BaseClient__, and for queering  __BaseQuery__, __GetRequest__.

This common models components to serialize response data:
* __NameIdPair__ 
* __IdTypePaire__ 
* __IdTypePairCollectionData__ 
* __CurrencyValuePair__ 

### Usage
#### BaseClient.cs

The public abstract class BaseClient is a parent class for all Clients in the SDK. 
It contains the only  protected virtual methods.

#### 1) ExecuteRequestAsync
This method is adding query parameters to *IRestRequest*, executing call to api and validate 
the response using method ValidateResponse.  

```C#
/// <summary>
/// Executes the request asynchronously.
/// </summary>
/// <typeparam name="T">Type of expected response.</typeparam>
/// <param name="request">The request.</param>
/// <param name="expectedStatusCode">The expected status code.</param>
/// <param name="query">The <see cref="IApiRequest" />.</param>
/// <returns></returns>
protected virtual async Task<T> ExecuteRequestAsync<T>(
    IRestRequest request,
    HttpStatusCode expectedStatusCode,
    IApiRequest query = null)
    where T : IApiResponse
    {
        AddQuiriesToRequest(ref request, query);
        var response = await _client.ExecuteAsync<T>(request);
        ValidateResponse(response, expectedStatusCode);
        return response.Data;
    }
```


#### 2) ValidateResponse

The base implementation of *ValidateResponse* method is comparing 
*Response Status Code with  Expected Code* and throws InvalidDataException
in case if the doesn't math.

```C#
protected virtual void ValidateResponse(IRestResponse response, HttpStatusCode expectedCode)
{
    if (response.StatusCode == expectedCode) return;
    var exceptionBuilder = new StringBuilder();
    exceptionBuilder.AppendLine("Invalid respond from the server.");
    exceptionBuilder.AppendLine("Current Status Code:" + response.StatusCode);
    if (!string.IsNullOrEmpty(response.ErrorMessage))
        exceptionBuilder.AppendLine("Error Message:" + response.ErrorMessage);
    if (!string.IsNullOrEmpty(response.Content))
        exceptionBuilder.AppendLine("Content:" + response.Content);
    throw new InvalidDataException(exceptionBuilder.ToString());
}
```

For example when you doesn't setup *IClientConfig* property **ConsumerKey** Without a valid API Key,
you will receive a 401 Status Code from API.
```Json
{
    "fault": {
        "faultstring": "Invalid ApiKey",
        "detail": {
            "errorcode": "oauth.v2.InvalidApiKey"
        }
    }
}
```

So exception for this response will be like this:

```
Invalid respond from the server.
Current Status Code:Unauthorized
Content: { \"fault\": { \"faultstring\": \"Invalid ApiKey\", \"detail\": { \"errorcode\": \"oauth.v2.InvalidApiKey\" } } }
```

____
### Dependencies

This packages is depended on [RestSharp](http://restsharp.org/) 