﻿//   Copyright © 2015-2021 Serhii Voznyi and open source community
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

    public class Genre
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Links Links { get; set; }

        public Embedded _embedded { get; set; }

        public class Embedded
        {
            public Embedded()
            {
                SubGenres = new List<SubGenre>();
            }

            public List<SubGenre> SubGenres { get; set; }
        }
    }
}