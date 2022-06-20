using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.ContactoExterno.DTO
{
    public class DTOAgente
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
