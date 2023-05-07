using AutoFixture;
using NSubstitute;
using Ticketmaster.Core;

namespace Ticketmaster.Discovery.Tests
{
    public abstract class TestBase
    {
        protected readonly IClientConfig Config;
        protected readonly Fixture Fixture;

        protected TestBase()
        {
            Fixture = new Fixture();
            Config = Substitute.For<IClientConfig>();
            Config.ConsumerKey.Returns("");
            Config.ApiRootUrl.Returns("https://app.ticketmaster.com/discovery/");
        }
    }
}
