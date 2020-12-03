namespace Ticketmaster.Core
{
    public class ClientFactory : IClientFactory
    {
        public TClient Create<TClient>(IClientConfig config) where TClient : IApiClient, new()
        {
            return (TClient) new TClient().Configure(config);
        }
    }
}