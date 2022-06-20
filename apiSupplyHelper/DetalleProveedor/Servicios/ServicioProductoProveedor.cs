using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.DetalleProveedor.DTO;
using apiSupplyHelper.DetalleProveedor.Modelos;
using apiSupplyHelper.Helpers;
using AutoMapper;

namespace apiSupplyHelper.DetalleProveedor.Servicios;

public interface IServicioProductoProveedor
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<ProductoProveedor> GetAll();
    ProductoProveedor GetById(int id);
    void Register(DTOProductoProveedor model);
    void Update(int id, DTOProductoProveedor model);
    void Delete(int id);
}
public class ServicioProductoProveedor: IServicioProductoProveedor
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioProductoProveedor(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }


    public IEnumerable<ProductoProveedor> GetAll()
    {
        return _context.ProductoProveedores;
    }

    public ProductoProveedor GetById(int id)
    {
        return GetProductoProveedor(id);
    }

    public void Register(DTOProductoProveedor model)
    {
        // validate
      //  if (_context.Agentes.Any(x => x.Nombre == model.Nombre) && _context.Agentes.Any(x => x.Apellido == model.Apellido) && _context.Agentes.Any(x => x.Telefono == model.Telefono))
        //    throw new AppException("Agente '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<ProductoProveedor>(model);

        // save user
        _context.ProductoProveedores.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOProductoProveedor model)
    {
        var user = GetProductoProveedor(id);

        // validate
       // if (model.Nombre != user.Nombre && _context.Agentes.Any(x => x.Nombre == model.Nombre))
         //   throw new AppException("Agente'" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.ProductoProveedores.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetProductoProveedor(id);
        _context.ProductoProveedores.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private ProductoProveedor GetProductoProveedor(int id)
    {
        var user = _context.ProductoProveedores.Find(id);
        if (user == null) throw new KeyNotFoundException("Detalle producto proveedor no encontrado");
        return user;
    }
}
