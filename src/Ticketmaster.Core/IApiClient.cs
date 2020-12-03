namespace Ticketmaster.Core
{
    public interface IApiClient
    {
        IApiClient Configure(IClientConfig config);
    }
}