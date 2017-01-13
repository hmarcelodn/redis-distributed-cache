using System;

namespace SouthWorks.Events.Infrastructure.Cache
{
    [Serializable]
    public class CacheItem
    {
        public string Id { get; set; }

        public byte[] Item { get; set; }

        public DateTime Expiration { get; set; }
    }
}
