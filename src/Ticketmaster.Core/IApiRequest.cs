namespace Ticketmaster.Core
{
    using System.Collections.Generic;

    public interface IApiRequest
    {
        IEnumerable<KeyValuePair<string, string>> QueryParameters { get; }
    }
}