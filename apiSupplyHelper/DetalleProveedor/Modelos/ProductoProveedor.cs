using apiSupplyHelper.Productos.Modelos;
using apiSupplyHelper.Proveedores.Modelos;

namespace apiSupplyHelper.DetalleProveedor.Modelos
{
    public class ProductoProveedor
    {
        public int Id { get; set; }
        public double precioUnitario { get; set; }
        public double pesoUnitario { get; set; }
        public double cantidadMinima { get; set; }
        public string unidadMedida { get; set; }
        public string Presentacion { get; set; }
        public int ProveedorId { get; set; }
        public int ProductoId { get; set; }
        public Proveedor? Proveedor { get; set; }
        public Producto? Producto { get; set; }
    }
}
