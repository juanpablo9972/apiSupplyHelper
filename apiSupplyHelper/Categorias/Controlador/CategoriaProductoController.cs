using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Categorias.DTO;
using apiSupplyHelper.Categorias.Servicios;
using apiSupplyHelper.Data.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.Categorias.Controlador;
[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoriaProductoController : ControllerBase
{
    private IServicioCategoriaProducto _servicioCategoriaProducto;
    public CategoriaProductoController(IServicioCategoriaProducto servicioCategoriaProducto)
    {
        _servicioCategoriaProducto = servicioCategoriaProducto;
    }

    [Authorize(Role.Admin,Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOCategoriaProducto model)
    {
        _servicioCategoriaProducto.Register(model);
        return Ok(new { message = "Se guardo la categoria de producto correctamente" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioCategoriaProducto.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOCategoriaProducto model)
    {
        _servicioCategoriaProducto.Update(id, model);
        return Ok(new { message = "Categoria de Producto modificada exitosamente" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioCategoriaProducto.Delete(id);
        return Ok(new { message = "Categoria de Producto eliminada exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioCategoriaProducto.GetById(id);
        return Ok(user);
    }
}
