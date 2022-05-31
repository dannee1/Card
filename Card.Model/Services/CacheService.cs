using Card.Domain.Entities.CardAggregate;
using Card.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Card.Domain.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }


        public long CacheToken(long token)
        {
            return _memoryCache.GetOrCreate(
                            token,
                            cacheEntry =>
                            {
                                var cacheEntryOptions = new MemoryCacheEntryOptions()
                                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                                _memoryCache.Set(token, token, cacheEntryOptions);
                                return token;
                            });
        }

        public object Get(long token)
        {
            return this._memoryCache.Get(token);
        }

    }
}
