public class Phong{
    public string? IdPhong{get;set;}
    public List<Player>? ListPlayer{get;set;}
}
public class Player{
    public string? Id{get;set;}
    public string? NamePlayer{get;set;}
    public int ViTri{get;set;}
    public Bullet? Bullet{get;set;}
    public int GocXoay{get;set;}
    public int SoDiem{get;set;}
}
public class Bullet{
    public int x{get;set;}
    public int y{get;set;}
}