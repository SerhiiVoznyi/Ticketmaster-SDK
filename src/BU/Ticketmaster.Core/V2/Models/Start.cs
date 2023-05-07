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

namespace Ticketmaster.Core.V2.Models
{
    using System;

    public class Start
    {
        public bool DateTba { get; set; }
        public bool DateTbd { get; set; }
        public DateTime DateTime { get; set; }
        public string LocalDate { get; set; }
        public string LocalTime { get; set; }
        public bool NoSpecificTime { get; set; }
        public bool TimeTba { get; set; }
    }
}