using apiSupplyHelper.Detalle_Pedido.DTO;
using apiSupplyHelper.Detalle_Pedido.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Detalle_Pedido.Mapeo;

public class MapeoDetallePedidoProducto: Profile
{
    public MapeoDetallePedidoProducto()
    {
        CreateMap<DTODetallePedidoProducto, detallePedidoProducto>();
    }
}
