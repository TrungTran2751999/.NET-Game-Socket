using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class SocketService:ISocketService
{
    private readonly IMemoryCache _memoryCache;
    public SocketService(IMemoryCache memoryCache){
        this._memoryCache = memoryCache;
    }
    public Phong TimPhong(Player player){
        var listPhong = (List<Phong>)UtilService.GetCachingData(_memoryCache, "room");
        if(listPhong!=null){
            foreach(var phong in listPhong){
                if(phong.ListPlayer?.Count < 4 ){
                    phong.ListPlayer.Add(player);
                    player.ViTri = phong.ListPlayer.Count-1;
                    return phong;
                }
            }
            //khoi tao phong khi la nguoi choi dau tien vao phong
            var newPhong = new Phong{
                IdPhong = Guid.NewGuid().ToString(),
                ListPlayer = new List<Player>(),
            };
            listPhong.Add(newPhong);
            return newPhong;
        }else{
            //khoi tao khi la nguoi choi dau tien choi phong dau tien
            listPhong = new List<Phong>();
            var newPhong = new Phong{
                IdPhong = Guid.NewGuid().ToString(),
                ListPlayer = new List<Player>(),
            };
            newPhong.ListPlayer.Add(player);
            listPhong.Add(newPhong);
            UtilService.SetCachingData(_memoryCache, newPhong, "room");
            return newPhong;
        }
    }
}