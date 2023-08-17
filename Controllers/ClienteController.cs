using DotNetTestetec.DAL;
using DotNetTestetec.Modal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace ClienteController;


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
    public IEnumerable<Cliente> GetAllCliente()
    {
        List<Cliente> Cliente = ClienteDataAccess.GetAllCliente();
        return Cliente;
    }

    [HttpPost]
    [EnableCors()]
    public IActionResult InsertNewCliente(Cliente Cliente)
    {
        ClienteDataAccess.SaveNewCliente(Cliente);
        return Ok(new { message = "Cliente created" });
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]
    public IActionResult DeleteOneCliente(Guid id)
    {
        ClienteDataAccess.DeleteClienteById(id);
        return Ok(new { message = "Cliente deleted" });
    }

    [Route("{id}")]
    [HttpPut]
    [EnableCors()]
    public IActionResult UpdateCliente(Guid id, [FromBody] Cliente Cliente)
    {
        ClienteDataAccess.UpdateCliente(id, Cliente);
        return Ok(new { message = "Cliente updated" });
    }
}