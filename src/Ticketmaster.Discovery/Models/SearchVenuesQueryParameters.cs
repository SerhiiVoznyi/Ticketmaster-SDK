//   Copyright © 2015-2026 Serhii Voznyi and the open source community
//
//     https://www.linkedin.com/in/serhii-voznyi/
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   You may not use this file except in compliance with the License.
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
    public enum SearchVenuesQueryParameters
    {
        keyword = 1,
        locale = 2,
        size = 3,
        page = 4,
        sort = 5,
        stateCode = 6,
        countryCode = 7,
        includeTest = 8,
        source = 9,
        geoPoint = 10,
        radius = 11,
        unit = 12
    }
}
