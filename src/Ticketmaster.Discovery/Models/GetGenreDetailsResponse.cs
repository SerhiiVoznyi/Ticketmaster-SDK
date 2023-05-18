﻿//   Copyright © 2015-2023 Serhii Voznyi and open source community
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

namespace Ticketmaster.Discovery.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Ticketmaster.Core;
    using Ticketmaster.Core.V2.Models;

    public class GetGenreDetailsResponse : IdNamePair, IApiResponse
    {
        [JsonPropertyName("_embedded")]
        public EmbeddedData Embedded { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        public class EmbeddedData
        {
            public IEnumerable<SubGenresData> SubGenres { get; set; }

            public EmbeddedData()
            {
                SubGenres = new List<SubGenresData>();
            }

            public class SubGenresData : IdNamePair
            {
                [JsonPropertyName("_links")]
                public Links Links { get; set; }
            }
        }
    }
}