using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.Productos.DTO;
using apiSupplyHelper.Productos.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.Productos.Controlador;
[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private IServicioProducto _servicioProducto;
    public ProductoController(IServicioProducto servicioProducto)
    {
        _servicioProducto = servicioProducto;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOProducto model)
    {
        _servicioProducto.Register(model);
        return Ok(new { message = "Se guardo el producto correctamente" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioProducto.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOProducto model)
    {
        _servicioProducto.Update(id, model);
        return Ok(new { message = "Producto modificado exitosamente" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioProducto.Delete(id);
        return Ok(new { message = "Producto eliminado exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioProducto.GetById(id);
        return Ok(user);
    }
}
