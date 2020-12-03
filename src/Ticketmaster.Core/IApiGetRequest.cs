namespace Ticketmaster.Core
{
    public interface IApiGetRequest : IApiRequest
    {
        string Id { get; set; }
    }
}