using apiSupplyHelper.Categorias.Modelos;
using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Productos.DTO;

public class DTOProducto
{
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Descripcion { get; set; }
    [Required]
    public int CategoriaProductoId { get; set; }

}
