using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Categorias.DTO;

public class DTOCategoriaProducto
{
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Descripcion { get; set; }
}
