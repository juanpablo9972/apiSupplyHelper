using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Categorias.DTO;
using apiSupplyHelper.Categorias.Servicios;
using apiSupplyHelper.Data.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.Categorias.Controlador;
[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoriaServicioController : ControllerBase
{
    private IServicioCategoriaServicio _servicioCategoriaServicio;
    public CategoriaServicioController(IServicioCategoriaServicio servicioCategoriaServicio)
    {
        _servicioCategoriaServicio = servicioCategoriaServicio;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOCategoriaServicio model)
    {
        _servicioCategoriaServicio.Register(model);
        return Ok(new { message = "Se guardo la categoria de servicio correctamente" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioCategoriaServicio.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOCategoriaServicio model)
    {
        _servicioCategoriaServicio.Update(id, model);
        return Ok(new { message = "Categoria de Servicio modificada exitosamente" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioCategoriaServicio.Delete(id);
        return Ok(new { message = "Categoria de Servicio eliminada exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioCategoriaServicio.GetById(id);
        return Ok(user);
    }
}
