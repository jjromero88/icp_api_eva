using PCM.SIP.ICP.EVA.Aplicacion.Interface.Infraestructure;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;

namespace PCM.SIP.ICP.EVA.Infraestructure.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            try
            {
                var result = await _distributedCache.GetAsync(key);

                if (result == null)
                    throw new Exception("An unexpected error: No se encontro el valor en la caché");

                return JsonSerializer.Deserialize<T>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while getting value in cache for key {Key}", ex);
            }
        }

        public async Task SetAsync<T>(string key, T value, int absoluteExpiration, int slidingExpiration)
        {
            try
            {
                var serializeData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));
                var options = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromMinutes(absoluteExpiration))
                            .SetSlidingExpiration(TimeSpan.FromMinutes(slidingExpiration));

                await _distributedCache.SetAsync(key, serializeData, options);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while setting value in cache for key {Key}", ex);
            }
        }
    }
}
