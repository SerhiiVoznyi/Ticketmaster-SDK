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

namespace Ticketmaster.Discovery.Models
{
    public enum SearchEventsQueryParameters
    {
        keyword = 1,
        attractionId = 2,
        venueId = 3,
        postalCode = 4,
        latlong = 5,
        radius = 6,
        unit = 7,
        source = 8,
        locale = 9,
        marketId = 10,
        startDateTime = 11,
        endDateTime = 12,
        includeTBA = 13,
        includeTBD = 14,
        includeTest = 15,
        size = 16,
        page = 17,
        sort = 18,
        onsaleStartDateTime = 19,
        onsaleEndDateTime = 20,
        city = 21,
        countryCode = 22,
        stateCode = 23,
        classificationName = 24,
        classificationId = 25,
        dmaId = 26,
        onsaleOnStartDate = 27,
        onsaleOnAfterStartDate = 28,
        segmentId = 29,
        segmentName = 30,
        promoterId = 31,
        clientVisibility = 32,
        nlp = 33,
        geoPoint = 34,
        includeLicensedContent = 35
    }
}