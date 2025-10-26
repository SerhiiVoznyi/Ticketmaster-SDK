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

using Ticketmaster.Discovery.Constants;

namespace Ticketmaster.Discovery.Models
{
    public class SearchEventsRequest : BaseQuery<SearchEventsRequest, string>, IApiRequest
    {
        public override SearchEventsRequest AddQueryParameter<TValue>(
            string parameter,
            TValue value)
        {
            AddParameter(parameter, value);
            return this;
        }

        public SearchEventsRequest AddQueryByPreSaleDateTime(
            DateTime? startDate,
            DateTime? endDate
            )
        {
            var startString = startDate?.ToString(ApiConstraints.DateTimeFormat) ?? "*";
            var endString = endDate?.ToString(ApiConstraints.DateTimeFormat) ?? "*";

            AddParameter(KnownQueryParameters.PreSaleDateTime, $"{startString},{endString}");
            return this;
        }
    }
}