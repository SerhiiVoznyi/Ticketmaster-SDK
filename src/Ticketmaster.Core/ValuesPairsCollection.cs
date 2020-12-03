namespace Ticketmaster.Core
{
    using System.Collections.Generic;

    public interface IValuesPairsCollection<out T> where T : class
    {
        IReadOnlyCollection<T> Values { get; }
    }
}