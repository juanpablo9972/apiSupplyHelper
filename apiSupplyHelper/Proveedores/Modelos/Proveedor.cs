using apiSupplyHelper.ContactoExterno.Modelos;
using apiSupplyHelper.DetalleProveedor.Modelos;

namespace apiSupplyHelper.Proveedores.Modelos
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Pais { get; set; }
        public int CodigoPostal { get; set; }

        public List<Agente>? Agentes { get; set; }
        public List<ProductoProveedor>? ProductoProveedores { get; set; }
        public List<ServicioProveedor>? ServicioProveedores { get; set; }
    }
}
