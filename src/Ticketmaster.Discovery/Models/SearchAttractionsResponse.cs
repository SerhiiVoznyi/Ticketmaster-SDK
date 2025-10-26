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

using System.Text.Json.Serialization;

namespace Ticketmaster.Discovery.Models
{
    using System.Collections.Generic;

    public class SearchAttractionsResponse : IApiResponse
    {
        [JsonPropertyName("_embedded")]
        public EmbeddedData Embedded { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        public Page Page { get; set; }

        public class EmbeddedData
        {
            public List<Attraction> Attractions { get; set; }

            public EmbeddedData()
            {
                Attractions = new List<Attraction>();
            }
        }
    }
}