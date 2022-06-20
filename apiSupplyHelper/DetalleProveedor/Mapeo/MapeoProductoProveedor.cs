using apiSupplyHelper.DetalleProveedor.DTO;
using apiSupplyHelper.DetalleProveedor.Modelos;
using AutoMapper;

namespace apiSupplyHelper.DetalleProveedor.Mapeo;

public class MapeoProductoProveedor: Profile
{
    public MapeoProductoProveedor()
    {
        CreateMap<DTOProductoProveedor, ProductoProveedor>();
    }
}
