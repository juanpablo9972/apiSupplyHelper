using apiSupplyHelper.Categorias.Modelos;

namespace apiSupplyHelper.Productos.Modelos;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public int CategoriaProductoId { get; set; }

    public CategoriaProducto? CategoriaProducto { get; set; }
}
