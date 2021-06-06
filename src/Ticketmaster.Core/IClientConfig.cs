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
namespace Ticketmaster.Core
{
    /// <summary>
    ///     The ICredentials interface keeps customer
    ///     credentials for Api endpoints.
    /// </summary>
    public interface IClientConfig
    {
        /// <summary>
        ///     Gets the Consumer API key for current customer.
        /// </summary>
        /// <value>
        ///     The string Consumer Api Key.
        /// </value>
        string ConsumerKey { get; }

        /// <summary>
        ///     Gets the root URL for ticket master web api.
        /// </summary>
        /// <value>
        ///     The api root URL
        ///     <example>https://app.ticketmaster.com/discovery/</example>
        ///     .
        /// </value>
        string ApiRootUrl { get; }
    }
}