using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.Proveedores.DTO;
using apiSupplyHelper.Proveedores.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.Proveedores.Controlador;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProveedorController : ControllerBase
{
    private IServicioProveedor _servicioProveedor;
    public ProveedorController(IServicioProveedor servicioProveedor)
    {
        _servicioProveedor = servicioProveedor;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOProveedor model)
    {
        _servicioProveedor.Register(model);
        return Ok(new { message = "Se guardo el proveedor correctamente" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioProveedor.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOProveedor model)
    {
        _servicioProveedor.Update(id, model);
        return Ok(new { message = "Proveedor modificado exitosamente" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioProveedor.Delete(id);
        return Ok(new { message = "Proveedor eliminado exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioProveedor.GetById(id);
        return Ok(user);
    }
}
