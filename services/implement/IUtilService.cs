using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

public interface IUtilService{
    void SetCachingData(object data, string cacheKey);
    object GetCachingData(string cacheKey);
}