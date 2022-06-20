namespace apiSupplyHelper.Detalle_Pedido.Mapeo;

using apiSupplyHelper.Detalle_Pedido.DTO;
using apiSupplyHelper.Detalle_Pedido.Modelos;
using AutoMapper;

public class MapeoPedido: Profile
{
    public MapeoPedido()
    {
        CreateMap<DTOPedido, Pedido>();
    }
}
