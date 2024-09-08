using app.Controllers;
using app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/socket")]
public class ApiSocketController:Controller{
    private ISocketService socketService;

    public ApiSocketController(ISocketService socketService){
        this.socketService = socketService;
    }

    [HttpPost]
    [Route("tim-phong")]
    public IActionResult TimPhong([FromBody] Player player){
        return Ok(socketService.TimPhong(player));
    }
}