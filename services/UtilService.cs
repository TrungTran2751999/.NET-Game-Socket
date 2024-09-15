using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class UtilService:IUtilService
{
    private readonly IMemoryCache cache;
    public UtilService(IMemoryCache cache){
        this.cache = cache;
    }
    public void SetCachingData(object data, string cacheKey){
        var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(500)); // Thời gian hết hạn 500 phút

        cache.Set(cacheKey, data, cacheEntryOptions);
    }
    public object GetCachingData(string cacheKey){
        if (cache.TryGetValue(cacheKey, out object cachedData))
        {
            return cachedData;
        }
        return null;
    }
    public static void XoaPhong(string idPhong){
        var phongDeXoa = SocketService.listPhong.Where(x=>x.IdPhong==idPhong && x.ListPlayer?.Count==0).FirstOrDefault();
        if(phongDeXoa!=null){
            SocketService.listPhong.Remove(phongDeXoa);
        }
    }
}