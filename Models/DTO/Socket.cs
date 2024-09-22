using System.Net.WebSockets;

public class Phong{
    public string? IdPhong{get;set;}
    public List<Player>? ListPlayer{get;set;}
}
public class Player{
    public string? Id{get;set;}
    public string? IdPhong{get;set;}
    public string? NamePlayer{get;set;}
    public int ViTri{get;set;}
    public Bullet? Bullet{get;set;}
    public double GocXoay{get;set;}
    public int SoDiem{get;set;}
    public StatusPlayer Status{get;set;}
    public int CapSung{get;set;}
}
public enum StatusPlayer{
    
    Thamgia,
    DangChoi,
    Thoat
}
public class Bullet{
    public int x{get;set;}
    public int y{get;set;}
}
public class SocketInfo{
    public string? IdPhong{get;set;}
    public string? IdPlayer{get;set;}
    public int ViTri{get;set;}
    public WebSocket? WebSocket{get;set;}
}