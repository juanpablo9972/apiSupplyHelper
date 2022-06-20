using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.Servicios.DTO;
using apiSupplyHelper.Servicios.Servicioss;
using Microsoft.AspNetCore.Mvc;

namespace apiSupplyHelper.Servicios.Controlador;
[Authorize]
[ApiController]
[Route("[controller]")]
public class ServicioController : ControllerBase
{
    private IServicioServicio _servicioServicio;
    public ServicioController(IServicioServicio servicioServicio)
    {
        _servicioServicio = servicioServicio;
    }

        [Authorize(Role.Admin, Role.Empleado)]
        [HttpPost("register")]
        public IActionResult Register(DTOServicio model)
        {
            _servicioServicio.Register(model);
            return Ok(new { message = "Se guardo el servicio correctamente" });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _servicioServicio.GetAll();
            return Ok(users);
        }

        [Authorize(Role.Admin, Role.Empleado)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, DTOServicio model)
        {
            _servicioServicio.Update(id, model);
            return Ok(new { message = "Servicio modificado exitosamente" });
        }

        [Authorize(Role.Admin, Role.Empleado)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _servicioServicio.Delete(id);
            return Ok(new { message = "Servicio eliminado exitosamente" });
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _servicioServicio.GetById(id);
            return Ok(user);
        }
}


