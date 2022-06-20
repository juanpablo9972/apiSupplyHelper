using apiSupplyHelper.DetalleProveedor.DTO;
using apiSupplyHelper.DetalleProveedor.Modelos;
using AutoMapper;

namespace apiSupplyHelper.DetalleProveedor.Mapeo;

public class MapeoServicioProveedor: Profile
{
    public MapeoServicioProveedor()
    {
        CreateMap<DTOServicioProveedor, ServicioProveedor>();
    }
}
