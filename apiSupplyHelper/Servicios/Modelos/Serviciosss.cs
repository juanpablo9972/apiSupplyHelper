using apiSupplyHelper.Categorias.Modelos;
using apiSupplyHelper.DetalleProveedor.Modelos;

namespace apiSupplyHelper.Servicios.Modelos
{
    public class Serviciosss
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int CategoriaServicioId { get; set; }

        public CategoriaServicio? CategoriaServicio { get; set; }

        public List<ServicioProveedor>? ServicioProveedores { get; set; }
    }
}
