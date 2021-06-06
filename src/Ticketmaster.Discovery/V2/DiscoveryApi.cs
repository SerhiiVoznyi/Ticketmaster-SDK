//   Copyright © 2015-2021 Serhii Voznyi and open source community
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
    using Core;
    using RestSharp;
    using System;
    using V2;

    /// <summary>
    ///     Defines the <see cref="DiscoveryApi" />.
    /// </summary>
    public class DiscoveryApi : IDiscoveryClient, IDisposable
    {
        /// <summary>
        ///     Defines the ExceptionPattern.
        /// </summary>
        private const string ExceptionPattern =
            "You try to access '{0}' client without it initialization. You should register clients in you DI container or call 'Configure' method before call '{0}'.";

        /// <summary>
        ///     Defines the _attractions.
        /// </summary>
        private Lazy<IAttractionsClient> _attractions;

        /// <summary>
        ///     Defines the _classifications.
        /// </summary>
        private Lazy<IClassificationsClient> _classifications;

        /// <summary>
        ///     Defines the _events.
        /// </summary>
        private Lazy<IEventsClient> _events;

        /// <summary>
        ///     Defines the _venues.
        /// </summary>
        private Lazy<IVenuesClient> _venues;

        /// <summary>
        ///     Defines the _suggestions.
        /// </summary>
        private Lazy<ISuggestionsClient> _suggestions;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscoveryApi" /> class.
        /// </summary>
        public DiscoveryApi()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscoveryApi" /> class.
        /// </summary>
        /// <param name="events">The events<see cref="IEventsClient" />.</param>
        /// <param name="venues">The venues<see cref="IVenuesClient" />.</param>
        /// <param name="attractions">The attractions<see cref="IAttractionsClient" />.</param>
        /// <param name="classifications">The classifications<see cref="IClassificationsClient" />.</param>
        /// <param name="suggestions">The suggestions<see cref="IClassificationsClient" />.</param>
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

        /// <summary>
        ///     The Configure.
        /// </summary>
        /// <param name="config">The config<see cref="IClientConfig" />.</param>
        /// <returns>The <see cref="IApiClient" />.</returns>
        public IApiClient Configure(IClientConfig config)
        {
            _events = new Lazy<IEventsClient>(() => new EventsClient(new RestClient(config.ApiRootUrl), config));
            _venues = new Lazy<IVenuesClient>(() => new VenuesClient(new RestClient(config.ApiRootUrl), config));
            _attractions = new Lazy<IAttractionsClient>(() => new AttractionsClient(new RestClient(config.ApiRootUrl), config));
            _classifications = new Lazy<IClassificationsClient>(() => new ClassificationsClient(new RestClient(config.ApiRootUrl), config));
            _suggestions = new Lazy<ISuggestionsClient>(() => new SuggestionsClient(new RestClient(config.ApiRootUrl), config));

            return this;
        }

        /// <summary>
        ///     Gets or sets the Events
        ///     <exception cref="NullReferenceException">
        ///         If <see cref="IEventsClient" />is null.
        ///     </exception>
        /// </summary>
        public IEventsClient Events
        {
            get => _events.Value ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Events)));

            protected set => _events = new Lazy<IEventsClient>(() => value);
        }

        /// <summary>
        ///     Gets or sets the Venues
        ///     <exception cref="NullReferenceException">
        ///         If <see cref="IVenuesClient" />is null.
        ///     </exception>
        /// </summary>
        public IVenuesClient Venues
        {
            get => _venues.Value ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Venues)));

            protected set => _venues = new Lazy<IVenuesClient>(() => value);
        }

        /// <summary>
        ///     Gets or sets the Attractions
        ///     <exception cref="NullReferenceException">
        ///         If <see cref="IAttractionsClient" />is null.
        ///     </exception>
        /// </summary>
        public IAttractionsClient Attractions
        {
            get => _attractions.Value ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Attractions)));

            protected set => _attractions = new Lazy<IAttractionsClient>(() => value);
        }

        /// <summary>
        ///     Gets or sets the Classifications
        ///     <exception cref="NullReferenceException">
        ///         If <see cref="IClassificationsClient" />is null.
        ///     </exception>
        /// </summary>
        public IClassificationsClient Classifications
        {
            get => _classifications.Value ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Classifications)));

            protected set => _classifications = new Lazy<IClassificationsClient>(() => value);
        }

        /// <summary>
        ///     Gets or sets the Suggestions
        ///     <exception cref="NullReferenceException">
        ///         If <see cref="ISuggestionsClient" />is null.
        ///     </exception>
        /// </summary>
        public ISuggestionsClient Suggestions
        {
            get => _suggestions.Value ?? throw new NullReferenceException(string.Format(ExceptionPattern, nameof(Suggestions)));

            protected set => _suggestions = new Lazy<ISuggestionsClient>(() => value);
        }

        public void Dispose()
        {
            _events = null;
            _venues = null;
            _attractions = null;
            _classifications = null;
        }
    }
}