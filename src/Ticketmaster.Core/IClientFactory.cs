namespace Ticketmaster.Core
{
    public interface IClientFactory
    {
        TClient Create<TClient>(IClientConfig config) where TClient : IApiClient, new();
    }
}