using Newtonsoft.Json;
using System;

namespace SouthWorks.Events.Infrastructure.Cache
{
    public class RedisCacheRepository : IKeyValueRepository
    {
        #region [ IKeyValueRepository Members ]

        public void Add(string key, object data)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            cache.StringSet(key, JsonConvert.SerializeObject(data));
        }

        public void Set(string key, object data)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();

            cache.StringSet(key, JsonConvert.SerializeObject(data));
        }

        public object Get(string key)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            var value = cache.StringGet(key);

            return (value.HasValue ? cache.StringGet(key).ToString() : string.Empty);
        }

        public void Remove(string key)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            cache.KeyDelete(key);
        }

        #endregion
    }
}
