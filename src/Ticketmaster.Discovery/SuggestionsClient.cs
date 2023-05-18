//   Copyright © 2015-2023 Serhii Voznyi and open source community
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

using RestSharp;
using System.Net;
using Ticketmaster.Core;
using Ticketmaster.Core.Extensions;
using Ticketmaster.Discovery.Models;

namespace Ticketmaster.Discovery
{
    public class SuggestionsClient : BaseClient, ISuggestionsClient
    {
        public const string SuggestPath = "/v2/suggest.json";

        public SuggestionsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<FindSuggestResponse> FindSuggest(FindSuggestRequest request) =>
            FindSuggest(request, CancellationToken.None);

        public async Task<FindSuggestResponse> FindSuggest(FindSuggestRequest request, CancellationToken ct)
        {
            return await Execute<FindSuggestResponse>(request.ToRestRequest(SuggestPath), request, HttpStatusCode.OK, ct);
        }
    }
}