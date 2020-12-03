namespace Ticketmaster.Core
{
    using Ticketmaster.Core.V2.Models;

    public abstract class ApiResponseBase<TData> : IApiResponse<TData>
    {
        public TData _embedded { get; set; }
        public TData Data => _embedded;
        public Links Links { get; set; }
        public Page Page { get; set; }
    }
}
