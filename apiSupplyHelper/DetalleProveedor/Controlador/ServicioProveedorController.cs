using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.DetalleProveedor.DTO;
using apiSupplyHelper.DetalleProveedor.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.DetalleProveedor.Controlador;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ServicioProveedorController: ControllerBase
{
    private IServicioServicioProveedor _servicioServicioProveedor;
    public ServicioProveedorController(IServicioServicioProveedor servicioServicioProveedor)
    {
        _servicioServicioProveedor = servicioServicioProveedor;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOServicioProveedor model)
    {
        _servicioServicioProveedor.Register(model);
        return Ok(new { message = "" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioServicioProveedor.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOServicioProveedor model)
    {
        _servicioServicioProveedor.Update(id, model);
        return Ok(new { message = "" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioServicioProveedor.Delete(id);
        return Ok(new { message = "" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioServicioProveedor.GetById(id);
        return Ok(user);
    }
}
