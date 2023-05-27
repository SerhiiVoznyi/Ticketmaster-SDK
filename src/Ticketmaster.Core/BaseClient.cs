//   Copyright © 2015-2024 Serhii Voznyi and open source community
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

namespace Ticketmaster.Core
{
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using RestSharp;

    public abstract class BaseClient
    {
        private readonly IRestClient _client;
        private readonly IClientConfig _config;

        protected BaseClient(
            IRestClient client,
            IClientConfig config)
        {
            _client = client;
            _config = config;
        }

        protected async Task<T> Execute<T>(
            RestRequest request,
            IApiRequest query,
            HttpStatusCode expectedStatusCode,
            CancellationToken ct)
            where T : IApiResponse
        {
            AddQueriesToRequest(ref request, query);
            var response = await _client.ExecuteAsync<T>(request, ct);
            ValidateResponse(response, expectedStatusCode);
            return response.Data;
        }

        protected virtual void AddQueriesToRequest(ref RestRequest request, IApiRequest query)
        {
            if (query == null) return;

            foreach (var parameter in query.QueryParameters)
                request.AddParameter(parameter.Key, parameter.Value, ParameterType.QueryString);
            request.AddParameter("apikey", _config.ConsumerKey, ParameterType.QueryString);
        }

        protected virtual void ValidateResponse(RestResponse response, HttpStatusCode expectedCode)
        {
            if (response.StatusCode == expectedCode) return;

            var exceptionBuilder = new StringBuilder();
            exceptionBuilder.AppendLine("Invalid response from the server.");
            exceptionBuilder.AppendLine("Current Status Code:" + response.StatusCode);
            if (!string.IsNullOrEmpty(response.ErrorMessage))
                exceptionBuilder.AppendLine("Error Message:" + response.ErrorMessage);
            if (!string.IsNullOrEmpty(response.Content))
                exceptionBuilder.AppendLine("Content:" + response.Content);
            throw new InvalidDataException(exceptionBuilder.ToString());
        }
    }
}