using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using app.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class SocketService:ISocketService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUtilService utilService;
    public static List<Phong> listPhong = new List<Phong>();

    public SocketService(IMemoryCache memoryCache, IUtilService utilService){
        this._memoryCache = memoryCache;
        this.utilService = utilService;
    }
    public Phong TimPhong(Player player){
        var listPhong = (List<Phong>)utilService.GetCachingData("room") ; 
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
            SocketService.listPhong = listPhong;
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
            SocketService.listPhong = listPhong;
            utilService.SetCachingData(listPhong, "room");
            return newPhong;
        }
    }
}