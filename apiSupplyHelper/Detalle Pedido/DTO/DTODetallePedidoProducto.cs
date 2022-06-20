using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Detalle_Pedido.DTO;

public class DTODetallePedidoProducto
{
    [Required]
    public double Cantidad { get; set; }
    [Required]
    public double Subtotal { get; set; }
    [Required]
    public int PedidoId { get; set; }
    [Required]
    public int ProductoProveedorId { get; set; }
}
