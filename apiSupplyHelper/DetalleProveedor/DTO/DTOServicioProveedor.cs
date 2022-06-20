using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.DetalleProveedor.DTO;

public class DTOServicioProveedor
{
    [Required]
    public double precio { get; set; }
    [Required]
    public int ProveedorId { get; set; }
    [Required]
    public int ServiciosssId { get; set; }
}
