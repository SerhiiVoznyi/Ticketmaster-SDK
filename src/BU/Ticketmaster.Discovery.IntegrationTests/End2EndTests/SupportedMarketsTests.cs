namespace Ticketmaster.Discovery.IntegrationTests.End2EndTests
{
    using Ticketmaster.Core;
    using Shouldly;
    using System.Threading.Tasks;
    using Ticketmaster.Discovery.V2.Models;
    using Xunit;

    public partial class DiscoveryApiClientTests
    {
        [Theory]
        [InlineData(Markets.AustraliaAndNewZealand.New_South_Wales_Australian_Capital_Territory)]
        [InlineData(Markets.AustraliaAndNewZealand.Queensland)]
        [InlineData(Markets.AustraliaAndNewZealand.Western_Australi)]
        [InlineData(Markets.AustraliaAndNewZealand.Victoria_Tasmania)]
        [InlineData(Markets.AustraliaAndNewZealand.Western_Australia)]
        [InlineData(Markets.AustraliaAndNewZealand.North_Island)]
        [InlineData(Markets.AustraliaAndNewZealand.South_Island)]
        public async Task Events_SearchEventsAsync_ShouldReturnResult_ForAustraliaAndNewZealandMarkets(
            Markets.AustraliaAndNewZealand market)
        {
            SearchEventsResponse result;

            using (var sut = _factory.Create<DiscoveryApi>(_config))
            {
                var request = new SearchEventsRequest();
                request.AddQueryParameter(SearchEventsQueryParameters.marketId, market.GetMarketId());
                await Task.Delay(ApiConstraints.RequiredRequestDelay);
                result = await sut.Events.SearchEventsAsync(request);
            }

            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(Markets.Canada.Toronto_Hamilton_And_Area)]
        [InlineData(Markets.Canada.Ottawa_And_Eastern_Ontario)]
        [InlineData(Markets.Canada.Manitoba)]
        [InlineData(Markets.Canada.Edmonton_And_Northern_Alberta)]
        [InlineData(Markets.Canada.Calgary_And_Southern_Alberta)]
        [InlineData(Markets.Canada.B_C_Interior)]
        [InlineData(Markets.Canada.Vancouver_And_Area)]
        [InlineData(Markets.Canada.Saskatchewan)]
        [InlineData(Markets.Canada.Montreal_And_Area)]
        public async Task Events_SearchEventsAsync_ShouldReturnResult_ForCanadianMarkets(Markets.Canada market)
        {
            SearchEventsResponse result;

            using (var sut = _factory.Create<DiscoveryApi>(_config))
            {
                var request = new SearchEventsRequest();
                request.AddQueryParameter(SearchEventsQueryParameters.marketId, market.GetMarketId());
                await Task.Delay(ApiConstraints.RequiredRequestDelay);
                result = await sut.Events.SearchEventsAsync(request);
            }

            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(Markets.Europe.UK_London)]
        [InlineData(Markets.Europe.UK_South)]
        [InlineData(Markets.Europe.UK_Midlands_And_Central)]
        [InlineData(Markets.Europe.UK_Wales_And_North_West)]
        [InlineData(Markets.Europe.UK_North_And_North_East)]
        [InlineData(Markets.Europe.Scotland)]
        [InlineData(Markets.Europe.Ireland)]
        [InlineData(Markets.Europe.Northern_Ireland)]
        [InlineData(Markets.Europe.Germany)]
        [InlineData(Markets.Europe.Netherlands)]
        [InlineData(Markets.Europe.Sweden)]
        [InlineData(Markets.Europe.Spain)]
        [InlineData(Markets.Europe.Spain_Barcelona)]
        [InlineData(Markets.Europe.Spain_Madrid)]
        [InlineData(Markets.Europe.Turkey)]
        public async Task Events_SearchEventsAsync_ShouldReturnResult_ForEuropeanMarkets(Markets.Europe market)
        {
            SearchEventsResponse result;

            using (var sut = _factory.Create<DiscoveryApi>(_config))
            {
                var request = new SearchEventsRequest();
                request.AddQueryParameter(SearchEventsQueryParameters.marketId, market.GetMarketId());
                await Task.Delay(ApiConstraints.RequiredRequestDelay);
                result = await sut.Events.SearchEventsAsync(request);
            }

            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(Markets.Mexico.Mexico_City_And_Metropolitan_Area)]
        [InlineData(Markets.Mexico.Monterrey)]
        [InlineData(Markets.Mexico.Guadalajara)]
        public async Task Events_SearchEventsAsync_ShouldReturnResult_ForMexicoMarkets(Markets.Mexico market)
        {
            SearchEventsResponse result;

            using (var sut = _factory.Create<DiscoveryApi>(_config))
            {
                var request = new SearchEventsRequest();
                request.AddQueryParameter(SearchEventsQueryParameters.marketId, market.GetMarketId());
                await Task.Delay(ApiConstraints.RequiredRequestDelay);
                result = await sut.Events.SearchEventsAsync(request);
            }

            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(Markets.USA.Birmingham_Amd_More)]
        [InlineData(Markets.USA.Charlotte)]
        [InlineData(Markets.USA.Chicagoland_And_Northern_IL)]
        [InlineData(Markets.USA.Cincinnati_And_Dayton)]
        [InlineData(Markets.USA.Dallas_Fort_Worth_And_More)]
        [InlineData(Markets.USA.Denver_And_More)]
        [InlineData(Markets.USA.Detroit_Toledo_And_More)]
        [InlineData(Markets.USA.El_Paso_And_New_Mexico)]
        [InlineData(Markets.USA.Grand_Rapids_And_More)]
        [InlineData(Markets.USA.Greater_Atlanta_Area)]
        [InlineData(Markets.USA.Greater_Boston_Area)]
        [InlineData(Markets.USA.Cleveland_Youngstown_And_More)]
        [InlineData(Markets.USA.Greater_Columbus_Area)]
        [InlineData(Markets.USA.Greater_Las_Vegas_Area)]
        [InlineData(Markets.USA.Greater_Miami_Area)]
        [InlineData(Markets.USA.Minneapolis_Paul_And_More)]
        [InlineData(Markets.USA.Greater_Orlando_Area)]
        [InlineData(Markets.USA.Greater_Philadelphia_Area)]
        [InlineData(Markets.USA.Greater_Pittsburgh_Area)]
        [InlineData(Markets.USA.Greater_San_Diego_Area)]
        [InlineData(Markets.USA.Greater_Tampa_Area)]
        [InlineData(Markets.USA.Houston_And_More)]
        [InlineData(Markets.USA.Indianapolis_And_More)]
        [InlineData(Markets.USA.Iowa)]
        [InlineData(Markets.USA.Jacksonville_And_More)]
        [InlineData(Markets.USA.Kansas_City_And_More)]
        [InlineData(Markets.USA.Greater_Los_Angeles_Area)]
        [InlineData(Markets.USA.Louisville_And_Lexington)]
        [InlineData(Markets.USA.Memphis_Little_Rock_And_More)]
        [InlineData(Markets.USA.Milwaukee_And_WI)]
        [InlineData(Markets.USA.Nashville_Knoxville_And_More)]
        [InlineData(Markets.USA.New_England)]
        [InlineData(Markets.USA.New_Orleans_And_More)]
        [InlineData(Markets.USA.New_York_Tri_State_Area)]
        [InlineData(Markets.USA.Phoenix_And_Tucson)]
        [InlineData(Markets.USA.Portland_And_More)]
        [InlineData(Markets.USA.Raleigh_And_Durham)]
        [InlineData(Markets.USA.Saint_Louis_And_More)]
        [InlineData(Markets.USA.San_Antonio_And_Austin)]
        [InlineData(Markets.USA.N_California_N_Nevada)]
        [InlineData(Markets.USA.Greater_Seattle_Area)]
        [InlineData(Markets.USA.North_And_South_Dakota)]
        [InlineData(Markets.USA.Upstate_New_York)]
        [InlineData(Markets.USA.Utah_And_Montana)]
        [InlineData(Markets.USA.Virginia)]
        [InlineData(Markets.USA.Washington_DC_And_Maryland)]
        [InlineData(Markets.USA.West_Virginia)]
        [InlineData(Markets.USA.Hawaii)]
        [InlineData(Markets.USA.Alaska)]
        [InlineData(Markets.USA.Nebraska)]
        [InlineData(Markets.USA.Springfield)]
        [InlineData(Markets.USA.Central_Illinois)]
        [InlineData(Markets.USA.Northern_New_Jersey)]
        [InlineData(Markets.USA.South_Carolina)]
        [InlineData(Markets.USA.South_Texas)]
        [InlineData(Markets.USA.Beaumont)]
        [InlineData(Markets.USA.Connecticut)]
        [InlineData(Markets.USA.Oklahoma)]
        public async Task Events_SearchEventsAsync_ShouldReturnResult_ForUSAMarkets(Markets.USA market)
        {
            SearchEventsResponse result;

            using (var sut = _factory.Create<DiscoveryApi>(_config))
            {
                var request = new SearchEventsRequest();
                request.AddQueryParameter(SearchEventsQueryParameters.marketId, market.GetMarketId());
                await Task.Delay(ApiConstraints.RequiredRequestDelay);
                result = await sut.Events.SearchEventsAsync(request);
            }

            result.ShouldNotBeNull();
        }
    }
}