﻿//   Copyright © 2015-2024 Serhii Voznyi and open source community
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

using Ticketmaster.Discovery.Constants;

namespace Ticketmaster.Discovery.Models
{
    public abstract class BaseQuery<TRequest, TParameter>
    {
        private readonly Dictionary<string, string> Parameters;

        protected BaseQuery()
        {
            Parameters = new Dictionary<string, string>();
        }

        public IEnumerable<KeyValuePair<string, string>> QueryParameters => Parameters;

        private string Normalize<TValue>(TValue value)
        {
            if (value is DateTime time) return time.ToString(ApiConstraints.DateTimeFormat);

            return value.ToString();
        }

        public abstract TRequest AddQueryParameter<TValue>(TParameter parameterName, TValue value);

        protected void AddParameter<TValue>(TParameter parameterName, TValue value)
        {
            var key = parameterName.ToString();
            if (Parameters.ContainsKey(key)) Parameters.Remove(key);

            Parameters.Add(key, Normalize(value));
        }
    }
}