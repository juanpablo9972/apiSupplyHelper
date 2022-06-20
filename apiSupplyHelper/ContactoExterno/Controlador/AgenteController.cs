using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.ContactoExterno.DTO;
using apiSupplyHelper.ContactoExterno.Servicios;
using apiSupplyHelper.Data.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.ContactoExterno.Controlador;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AgenteController : ControllerBase
{
    private IServicioAgente _servicioAgente;
    public AgenteController(IServicioAgente servicioAgente)
    {
        _servicioAgente = servicioAgente;
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPost("register")]
    public IActionResult Register(DTOAgente model)
    {
        _servicioAgente.Register(model);
        return Ok(new { message = "Se guardo el agente correctamente" });
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _servicioAgente.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpPut("{id}")]
    public IActionResult Update(int id, DTOAgente model)
    {
        _servicioAgente.Update(id, model);
        return Ok(new { message = "Agente modificado exitosamente" });
    }

    [Authorize(Role.Admin, Role.Empleado)]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _servicioAgente.Delete(id);
        return Ok(new { message = "Agente eliminado exitosamente" });
    }

    [AllowAnonymous]
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var user = _servicioAgente.GetById(id);
        return Ok(user);
    }
}
