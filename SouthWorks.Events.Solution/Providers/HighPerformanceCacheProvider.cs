using Newtonsoft.Json;
using SouthWorks.Events.Infrastructure.Cache;
using SouthWorks.Events.Infrastructure.Serializer;
using System;
using System.Web.Caching;

namespace SouthWorks.Events.Solution.Providers
{
    public class HighPerformanceCacheProvider : OutputCacheProvider
    {
        protected IKeyValueRepository _redisRepository;
        protected IItemSerializer _binarySerializer;

        public HighPerformanceCacheProvider()
        {
            _redisRepository = new RedisCacheRepository();
            _binarySerializer = new BinaryFormatterItemSerializer();
        }

        #region [ OutputCacheProvider Members ]

        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            _redisRepository.Add(key, 
                new CacheItem()
                {
                     Expiration = utcExpiry,
                     Id = key,
                     Item = _binarySerializer.Serialize(entry)
                });

            return entry;
        }

        public override object Get(string key)
        {
            var value = (string)_redisRepository.Get(key);

            if (!string.IsNullOrEmpty(value))
            {
                var cacheItem = JsonConvert.DeserializeObject<CacheItem>(value);

                if (cacheItem.Expiration.ToUniversalTime() < DateTime.UtcNow)
                {
                    Remove(key);
                }
                else
                {
                    return _binarySerializer.Deserialize(cacheItem.Item);
                }
            }

            return null;
        }

        public override void Remove(string key)
        {
            _redisRepository.Remove(key);
        }

        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            _redisRepository.Set(key,
                new CacheItem()
                {
                    Expiration = utcExpiry,
                    Id = key,
                    Item = _binarySerializer.Serialize(entry)
                });
        }

        #endregion
    }
}