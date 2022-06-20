using apiSupplyHelper.DetalleProveedor.Modelos;

namespace apiSupplyHelper.Detalle_Pedido.Modelos;

public class detallePedidoProducto
{
    public int Id { get; set; }
    public double Cantidad { get; set; }
    public double Subtotal { get; set; }
    public int PedidoId { get; set; }
    public int ProductoProveedorId { get; set; }
    public Pedido? Pedido { get; set; }
    public ProductoProveedor? ProductoProveedor { get; set; }
}
