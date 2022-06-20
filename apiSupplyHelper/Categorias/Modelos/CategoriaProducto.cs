using apiSupplyHelper.Productos.Modelos;
namespace apiSupplyHelper.Categorias.Modelos;

public class CategoriaProducto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public List<Producto>? Productos { get; set; }
}
