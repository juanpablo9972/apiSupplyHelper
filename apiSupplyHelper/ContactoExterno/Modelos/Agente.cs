using apiSupplyHelper.Proveedores.Modelos;

namespace apiSupplyHelper.ContactoExterno.Modelos;

public class Agente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public int ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }
}
