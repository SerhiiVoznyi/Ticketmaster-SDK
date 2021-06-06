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

    public class Venue : BaseEvent, IApiResponse
    {
        public Venue()
        {
            Markets = new List<Market>();
        }

        public string Timezone { get; set; }
        public string PostalCode { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public Address Address { get; set; }
        public Location Location { get; set; }
        public Links Links { get; set; }
        public List<Market> Markets { get; set; }
    }
}