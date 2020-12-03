namespace Ticketmaster.Core
{
    using System.Collections.Generic;

    public class IdTypePairCollectionData
    {
        public IdTypePairCollectionData()
        {
            Data = new List<IdTypePair>();
        }

        public List<IdTypePair> Data { get; set; }
    }
}