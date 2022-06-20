using apiSupplyHelper.Productos.DTO;
using apiSupplyHelper.Productos.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Productos.Mapeo;

public class MapeoProducto: Profile
  
{
    public MapeoProducto()
    {
        CreateMap<DTOProducto, Producto>();
    }
}
