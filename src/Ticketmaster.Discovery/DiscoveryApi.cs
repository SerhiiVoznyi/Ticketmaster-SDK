//   Copyright © 2015-2026 Serhii Voznyi and open source community
//
//     https://www.linkedin.com/in/serhii-voznyi/
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// ReSharper disable once CheckNamespace

namespace Ticketmaster.Discovery
{
    using System;
    using RestSharp;

    public class DiscoveryApi : IDiscoveryClient, IDisposable
    {
        private const string ExceptionPattern =
            "You try to access '{0}' client without its initialization. Register clients in your DI container or call the 'Configure' method before calling '{0}'.";

        private Lazy<IAttractionsClient> _attractions;

        private Lazy<IClassificationsClient> _classifications;

        private Lazy<IEventsClient> _events;

        private Lazy<ISuggestionsClient> _suggestions;

        private Lazy<IVenuesClient> _venues;

        public DiscoveryApi(string consumerKey)
        {
            Configure(new Config(consumerKey));
        }

        public DiscoveryApi(IClientConfig config)
        {
            Configure(config);
        }

        public DiscoveryApi(
            IEventsClient events,
            IVenuesClient venues,
            IAttractionsClient attractions,
            IClassificationsClient classifications,
            ISuggestionsClient suggestions)
        {
            _events = new Lazy<IEventsClient>(() => events);
            _venues = new Lazy<IVenuesClient>(() => venues);
            _attractions = new Lazy<IAttractionsClient>(() => attractions);
            _classifications = new Lazy<IClassificationsClient>(() => classifications);
            _suggestions = new Lazy<ISuggestionsClient>(() => suggestions);
        }

        public IAttractionsClient Attractions
        {
            get => _attractions.Value
                ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Attractions)));

            protected set => _attractions = new Lazy<IAttractionsClient>(() => value);
        }

        public IClassificationsClient Classifications
        {
            get => _classifications.Value
                ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Classifications)));

            protected set => _classifications = new Lazy<IClassificationsClient>(() => value);
        }

        public IEventsClient Events
        {
            get => _events.Value
                ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Events)));

            protected set => _events = new Lazy<IEventsClient>(() => value);
        }

        public ISuggestionsClient Suggestions
        {
            get => _suggestions.Value
                ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Suggestions)));

            protected set => _suggestions = new Lazy<ISuggestionsClient>(() => value);
        }

        public IVenuesClient Venues
        {
            get => _venues.Value
                ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Venues)));

            protected set => _venues = new Lazy<IVenuesClient>(() => value);
        }

        public void Dispose()
        {
            _attractions = null;
            _classifications = null;
            _events = null;
            _suggestions = null;
            _venues = null;
        }

        private void Configure(IClientConfig config)
        {
            _events = new Lazy<IEventsClient>(() => new EventsClient(new RestClient(config.ApiRootUrl), config));
            _venues = new Lazy<IVenuesClient>(() => new VenuesClient(new RestClient(config.ApiRootUrl), config));
            _attractions = new Lazy<IAttractionsClient>(() => new AttractionsClient(new RestClient(config.ApiRootUrl), config));
            _classifications = new Lazy<IClassificationsClient>(() => new ClassificationsClient(new RestClient(config.ApiRootUrl), config));
            _suggestions = new Lazy<ISuggestionsClient>(() => new SuggestionsClient(new RestClient(config.ApiRootUrl), config));
        }
    }
}