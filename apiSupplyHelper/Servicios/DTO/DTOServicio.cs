using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Servicios.DTO
{
    public class DTOServicio
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int CategoriaServicioId { get; set; }
    }
}
