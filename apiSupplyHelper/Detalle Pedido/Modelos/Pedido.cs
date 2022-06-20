using apiSupplyHelper.Data.Models.Auth;

namespace apiSupplyHelper.Detalle_Pedido.Modelos;

public class Pedido
{
    public int Id { get; set; }
    public string Fecha { get; set; }
    public int CodigoPostal { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
    public List<detallePedidoProducto>? detallePedidoProductos { get; set; }
}
