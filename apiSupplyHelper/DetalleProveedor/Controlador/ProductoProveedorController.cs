using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.DetalleProveedor.DTO;
using apiSupplyHelper.DetalleProveedor.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.DetalleProveedor.Controlador;
[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductoProveedorController : Controller
{
    private IServicioProductoProveedor _servicioProductoProveedor;
    public ProductoProveedorController(IServicioProductoProveedor servicioProductoProveedor)
    {
        _servicioProductoProveedor = servicioProductoProveedor;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOProductoProveedor model)
    {
        _servicioProductoProveedor.Register(model);
        return Ok(new { message = "" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioProductoProveedor.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOProductoProveedor model)
    {
        _servicioProductoProveedor.Update(id, model);
        return Ok(new { message = "" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioProductoProveedor.Delete(id);
        return Ok(new { message = "" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioProductoProveedor.GetById(id);
        return Ok(user);
    }
}
