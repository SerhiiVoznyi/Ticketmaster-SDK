namespace Ticketmaster.Discovery.IntegrationTests.End2EndTests
{
    using Core;
    using NSubstitute;
    using System;
    using System.Security.Authentication;
    using V2;
    using Xunit;

    public partial class DiscoveryApiClientTests
    {
        private const string ApiConsumerKey = "";

        public DiscoveryApiClientTests()
        {
            if (string.IsNullOrEmpty(ApiConsumerKey))
            {
                throw new InvalidCredentialException($"Please specify '{nameof(ApiConsumerKey)}' before running e2e tests first");
            }
            _config = Substitute.For<IClientConfig>();
            _config.ConsumerKey.Returns(ApiConsumerKey);
            _config.ApiRootUrl.Returns("https://app.ticketmaster.com/discovery/");
            _factory = new ClientFactory();
            _sut = _factory.Create<DiscoveryApi>(_config);
        }

        private readonly DiscoveryApi _sut;
        private readonly IClientFactory _factory;
        private readonly IClientConfig _config;

        [Fact]
        public void DefaultConstructor_ShouldNot_Initialize_InternalClients()
        {
            var sut = new DiscoveryApi();

            Assert.Throws<NullReferenceException>(() => sut.Events);
            Assert.Throws<NullReferenceException>(() => sut.Attractions);
            Assert.Throws<NullReferenceException>(() => sut.Classifications);
            Assert.Throws<NullReferenceException>(() => sut.Venues);
        }

        [Fact]
        public void Configure_Should_Initialize_InternalClients()
        {
            var sut = new DiscoveryApi();

            sut.Configure(_config);

            Assert.NotNull(sut);
            Assert.IsType<DiscoveryApi>(sut);

            Assert.NotNull(sut.Events);
            Assert.IsType<EventsClient>(sut.Events);

            Assert.NotNull(sut.Attractions);
            Assert.IsType<AttractionsClient>(sut.Attractions);

            Assert.NotNull(sut.Venues);
            Assert.IsType<VenuesClient>(sut.Venues);

            Assert.NotNull(sut.Classifications);
            Assert.IsType<ClassificationsClient>(sut.Classifications);

            Assert.NotNull(sut.Suggestions);
            Assert.IsType<SuggestionsClient>(sut.Suggestions);
        }

        [Fact]
        public void ParameterizedConstructor_Should_Set_InternalClients()
        {
            var eventsClient = Substitute.For<IEventsClient>();
            var venuesClient = Substitute.For<IVenuesClient>();
            var attractionsClient = Substitute.For<IAttractionsClient>();
            var classificationsClient = Substitute.For<IClassificationsClient>();
            var suggestionsClient = Substitute.For<ISuggestionsClient>();

            var sut = new DiscoveryApi(eventsClient, venuesClient, attractionsClient, classificationsClient, suggestionsClient);

            Assert.Equal(eventsClient, sut.Events);
            Assert.Equal(venuesClient, sut.Venues);
            Assert.Equal(attractionsClient, sut.Attractions);
            Assert.Equal(classificationsClient, sut.Classifications);
            Assert.Equal(suggestionsClient, sut.Suggestions);
        }
    }
}
