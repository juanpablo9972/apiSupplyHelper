using apiSupplyHelper.Proveedores.DTO;
using apiSupplyHelper.Proveedores.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Proveedores.Mapeo;

public class MapeoProveedor: Profile
{
    public MapeoProveedor()
    {
        CreateMap<DTOProveedor, Proveedor>();
    }
}
