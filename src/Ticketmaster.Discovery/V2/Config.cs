namespace Ticketmaster.Discovery.V2
{
    using Core;

    public class Config : IClientConfig
    {
        public Config(string consumerKey)
        {
            ConsumerKey = consumerKey;
        }

        public string ConsumerKey { get; }

        public string ApiRootUrl => "https://app.ticketmaster.com/discovery/";
    }
}