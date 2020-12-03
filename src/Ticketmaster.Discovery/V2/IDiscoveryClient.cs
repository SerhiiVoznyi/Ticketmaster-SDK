// ReSharper disable once CheckNamespace

namespace Ticketmaster.Discovery
{
    using Core;
    using V2;

    public interface IDiscoveryClient : IApiClient
    {
        IEventsClient Events { get; }
        IVenuesClient Venues { get; }
        IAttractionsClient Attractions { get; }
        IClassificationsClient Classifications { get; }
    }
}