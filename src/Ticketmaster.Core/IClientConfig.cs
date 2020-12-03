namespace Ticketmaster.Core
{
    /// <summary>
    ///     The ICredentials interface keeps customer
    ///     credentials for Api endpoints.
    /// </summary>
    public interface IClientConfig
    {
        /// <summary>
        ///     Gets the Consumer API key for current customer.
        /// </summary>
        /// <value>
        ///     The string Consumer Api Key.
        /// </value>
        string ConsumerKey { get; }

        /// <summary>
        ///     Gets the root URL for ticket master web api.
        /// </summary>
        /// <value>
        ///     The api root URL
        ///     <example>https://app.ticketmaster.com/discovery/</example>
        ///     .
        /// </value>
        string ApiRootUrl { get; }
    }
}