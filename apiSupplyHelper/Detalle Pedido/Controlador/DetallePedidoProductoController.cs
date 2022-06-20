using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.Detalle_Pedido.DTO;
using apiSupplyHelper.Detalle_Pedido.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.Detalle_Pedido.Controlador;
[Authorize]
[ApiController]
[Route("[controller]")]
public class DetallePedidoProductoController : ControllerBase
{
    private IServicioDetallePedidoProducto _servicioDetallePedidoProducto;
    public DetallePedidoProductoController(IServicioDetallePedidoProducto servicioDetallePedidoProducto)
    {
        _servicioDetallePedidoProducto = servicioDetallePedidoProducto;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTODetallePedidoProducto model)
    {
        _servicioDetallePedidoProducto.Register(model);
        return Ok(new { message = "Se guardo el DetallePedidoProducto correctamente" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioDetallePedidoProducto.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTODetallePedidoProducto model)
    {
        _servicioDetallePedidoProducto.Update(id, model);
        return Ok(new { message = "DetallePedidoProducto modificado exitosamente" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioDetallePedidoProducto.Delete(id);
        return Ok(new { message = "DetallePedidoProducto eliminado exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioDetallePedidoProducto.GetById(id);
        return Ok(user);
    }
}
