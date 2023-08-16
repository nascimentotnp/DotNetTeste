using DotNetTestetec.DAL;
using DotNetTestetec.Modal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace DotNetTestetec.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
    public IEnumerable<Cliente> GetAllUsers()
    {
        List<Cliente> clientes = ClienteDataAccess.GetAllUsers();
        return clientes;
    }

    [HttpPost]
    [EnableCors()]
    public IActionResult InsertNewUser(Cliente cliente)
    {
        ClienteDataAccess.SaveNewUser(cliente);
        return Ok(new { message = "User created" });
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public IActionResult DeleteOneUser(int id)
    {
        ClienteDataAccess.DeleteUserById(id);
        return Ok(new { message = "User deleted" });
    }

    [Route("{id}")]
    [HttpPut]
    [EnableCors()]
    public IActionResult UpdateUser(int id, [FromBody] Cliente cliente)
    {
        ClienteDataAccess.UpdateUser(id, cliente);
        return Ok(new { message = "User updated" });
    }
}