using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class UtilService
{
    public static void SetCachingData(IMemoryCache cache, object data, string cacheKey){
        var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5)); // Thời gian hết hạn 5 phút

        cache.Set(cacheKey, data, cacheEntryOptions);
    }
    public static object GetCachingData(IMemoryCache cache, string cacheKey){
        if (cache.TryGetValue(cacheKey, out string cachedData))
        {
            return cachedData;
        }
        return null;
    }
}