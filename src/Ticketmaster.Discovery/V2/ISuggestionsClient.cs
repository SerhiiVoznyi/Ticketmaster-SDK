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
// ReSharper disable once CheckNamespace
namespace Ticketmaster.Discovery
{
    using System.Threading.Tasks;
    using Ticketmaster.Discovery.V2.Models;

    /// <summary>
    ///     The ISuggestionsClient interface.
    /// </summary>
    public interface ISuggestionsClient
    {
        /// <summary>
        ///      Find search suggestions and filter your suggestions by location, source, etc.
        /// </summary>
        /// <param name="request">The <see cref="FindSuggestRequest"/> request.</param>
        /// <returns>Task for <see cref="FindSuggestResponse"/>.</returns>
        Task<FindSuggestResponse> FindSuggestAsync(FindSuggestRequest request);
    }
}
