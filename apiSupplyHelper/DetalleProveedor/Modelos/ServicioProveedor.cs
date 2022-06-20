using apiSupplyHelper.Proveedores.Modelos;
using apiSupplyHelper.Servicios.Modelos;

namespace apiSupplyHelper.DetalleProveedor.Modelos;

public class ServicioProveedor
{
    public int Id { get; set; }
    public double precio { get; set; }
    public int ProveedorId { get; set; }
    public int ServiciosssId { get; set; }
    public Proveedor? Proveedor { get; set; }
    public Serviciosss? Serviciosss { get; set; }
}
