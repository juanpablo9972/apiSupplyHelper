using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.Detalle_Pedido.DTO;
using apiSupplyHelper.Detalle_Pedido.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.Detalle_Pedido.Controlador;
[Authorize]
[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private IServicioPedido _servicioPedido;
    public PedidoController(IServicioPedido servicioPedido)
    {
        _servicioPedido = servicioPedido;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOPedido model)
    {
        _servicioPedido.Register(model);
        return Ok(new { message = "Se guardo el Pedido correctamente" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioPedido.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOPedido model)
    {
        _servicioPedido.Update(id, model);
        return Ok(new { message = "Pedido modificado exitosamente" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioPedido.Delete(id);
        return Ok(new { message = "Pedido eliminado exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioPedido.GetById(id);
        return Ok(user);
    }
}
