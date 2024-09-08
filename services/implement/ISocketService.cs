using app.Models;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers;

public interface ISocketService{
    Phong TimPhong(Player player);
}