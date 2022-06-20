using apiSupplyHelper.ContactoExterno.DTO;
using apiSupplyHelper.ContactoExterno.Modelos;
using AutoMapper;

namespace apiSupplyHelper.ContactoExterno.Mapeo;

public class MapeoAgente: Profile
{
    public MapeoAgente()
    {
        CreateMap<DTOAgente, Agente>();
    }
}
