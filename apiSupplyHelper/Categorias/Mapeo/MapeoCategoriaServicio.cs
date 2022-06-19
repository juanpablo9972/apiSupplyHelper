using apiSupplyHelper.Categorias.DTO;
using apiSupplyHelper.Categorias.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Categorias.Mapeo;

public class MapeoCategoriaServicio : Profile
{
    public MapeoCategoriaServicio()
        {
    CreateMap<DTOCategoriaServicio, CategoriaServicio>();
        }
}
