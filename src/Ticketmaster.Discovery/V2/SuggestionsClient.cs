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
namespace Ticketmaster.Discovery.V2
{
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;
    using Ticketmaster.Core;
    using Ticketmaster.Discovery.V2.Models;

    public class SuggestionsClient : BaseClient, ISuggestionsClient
    {
        public const string SuggestPath = "/v2/suggest.json";

        public SuggestionsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<FindSuggestResponse> FindSuggestAsync(FindSuggestRequest request)
        {
            return ExecuteRequestAsync<FindSuggestResponse>(RequestHelper.CreateGetRequest(request, SuggestPath),
                HttpStatusCode.OK, request);
        }
    }
}
