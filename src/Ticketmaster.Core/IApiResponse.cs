namespace Ticketmaster.Core
{
    public interface IApiResponse
    {
    }

    public interface IApiResponse<TData> : IApiResponse
    {
        TData _embedded { get; set; }
        TData Data { get; }
    }
}