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
namespace Ticketmaster.Core.V2.Models
{
    using System.Collections.Generic;

    public class Event : BaseEvent, IApiResponse
    {
        public Event()
        {
            PriceRanges = new List<PriceRange>();
            Products = new List<Product>();
            Classifications = new List<Classification>();
        }

        public string Description { get; set; }
        public Dates Dates { get; set; }
        public Sales Sales { get; set; }
        public Links Links { get; set; }
        public Embedded _embedded { get; set; }
        public Promoter Promoter { get; set; }
        public Seatmap Seatmap { get; set; }
        public List<Classification> Classifications { get; set; }
        public List<PriceRange> PriceRanges { get; set; }
        public List<Product> Products { get; set; }

        public class Embedded
        {
            public Embedded()
            {
                Venues = new List<Venue>();
            }

            public List<Venue> Venues { get; set; }
        }
    }
}