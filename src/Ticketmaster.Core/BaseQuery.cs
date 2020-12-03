namespace Ticketmaster.Core
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseQuery<TRequest, TParameter> : IApiRequest
    {
        private readonly Dictionary<string, string> Parameters;

        protected BaseQuery()
        {
            Parameters = new Dictionary<string, string>();
        }

        protected void AddParameter<TValue>(TParameter parameterName, TValue value)
        {
            var key = parameterName.ToString();
            if (Parameters.ContainsKey(key))
            {
                Parameters.Remove(key);
            }

            Parameters.Add(key, Normalize(value));
        }

        public IEnumerable<KeyValuePair<string, string>> QueryParameters => Parameters;

        public abstract TRequest AddQueryParameter<TValue>(TParameter parameterName, TValue value);

        private string Normalize<TValue>(TValue value)
        {
            if (value is DateTime time)
            {
                return time.ToString(ApiConstraints.DateTimeFormat);
            }

            return value.ToString();
        }
    }
}