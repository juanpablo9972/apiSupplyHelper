using apiSupplyHelper.Categorias.DTO;
using apiSupplyHelper.Categorias.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Categorias.Mapeo;

public class MapeoCategoriaProducto: Profile
{
    public MapeoCategoriaProducto()
    {
        CreateMap<DTOCategoriaProducto, CategoriaProducto>();
    }
}
