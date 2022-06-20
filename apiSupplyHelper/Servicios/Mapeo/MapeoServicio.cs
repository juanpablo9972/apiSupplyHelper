using apiSupplyHelper.Servicios.DTO;
using apiSupplyHelper.Servicios.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Servicios.Mapeo
{
    public class MapeoServicio: Profile
    {
        public MapeoServicio()
        {
            CreateMap<DTOServicio, Serviciosss>();
        }
    }
}
