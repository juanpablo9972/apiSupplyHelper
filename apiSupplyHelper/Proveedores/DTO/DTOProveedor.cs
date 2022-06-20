using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Proveedores.DTO
{
    public class DTOProveedor
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public int CodigoPostal { get; set; }
    }
}
