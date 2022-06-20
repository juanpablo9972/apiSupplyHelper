using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Helpers;
using apiSupplyHelper.Productos.DTO;
using apiSupplyHelper.Productos.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Productos.Servicios;

public interface IServicioProducto
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Producto> GetAll();
    Producto GetById(int id);
    void Register(DTOProducto model);
    void Update(int id, DTOProducto model);
    void Delete(int id);
}
public class ServicioProducto: IServicioProducto
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioProducto(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }



    public IEnumerable<Producto> GetAll()
    {
        return _context.Products;
    }

    public Producto GetById(int id)
    {
        return GetProducto(id);
    }

    public void Register(DTOProducto model)
    {
        // validate
        if (_context.Products.Any(x => x.Nombre == model.Nombre))
            throw new AppException("Producto '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<Producto>(model);

        // save user
        _context.Products.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOProducto model)
    {
        var user = GetProducto(id);

        // validate
        if (model.Nombre != user.Nombre && _context.Products.Any(x => x.Nombre == model.Nombre))
            throw new AppException("Producto '" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Products.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetProducto(id);
        _context.Products.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private Producto GetProducto(int id)
    {
        var user = _context.Products.Find(id);
        if (user == null) throw new KeyNotFoundException("Producto no encontrado");
        return user;
    }
}
