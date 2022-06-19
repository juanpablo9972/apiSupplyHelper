using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Categorias.DTO;
using apiSupplyHelper.Categorias.Modelos;
using apiSupplyHelper.Helpers;
using AutoMapper;

namespace apiSupplyHelper.Categorias.Servicios;

public interface IServicioCategoriaProducto
{
   // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<CategoriaProducto> GetAll();
    CategoriaProducto GetById(int id);
    void Register(DTOCategoriaProducto model);
    void Update(int id, DTOCategoriaProducto model);
    void Delete(int id);
}

public class ServicioCategoriaProducto : IServicioCategoriaProducto
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioCategoriaProducto(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    

    public IEnumerable<CategoriaProducto> GetAll()
    {
        return _context.CategoriaProductos;
    }

    public CategoriaProducto GetById(int id)
    {
        return GetCategoriaProducto(id);
    }

    public void Register(DTOCategoriaProducto model)
    {
        // validate
        if (_context.CategoriaProductos.Any(x => x.Nombre == model.Nombre))
            throw new AppException("Categoria de Producto '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<CategoriaProducto>(model);

        // save user
        _context.CategoriaProductos.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOCategoriaProducto model)
    {
        var user = GetCategoriaProducto(id);

        // validate
        if (model.Nombre != user.Nombre && _context.CategoriaProductos.Any(x => x.Nombre == model.Nombre))
            throw new AppException("Nombre '" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.CategoriaProductos.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetCategoriaProducto(id);
        _context.CategoriaProductos.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private CategoriaProducto GetCategoriaProducto(int id)
    {
        var user = _context.CategoriaProductos.Find(id);
        if (user == null) throw new KeyNotFoundException("Categoria de Productos no encontrada");
        return user;
    }
}
