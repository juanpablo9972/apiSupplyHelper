using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Categorias.DTO
{
    public class DTOCategoriaServicio
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
