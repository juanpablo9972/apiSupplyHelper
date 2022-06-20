using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Helpers;
using apiSupplyHelper.Proveedores.DTO;
using apiSupplyHelper.Proveedores.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Proveedores.Servicios;

public interface IServicioProveedor
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Proveedor> GetAll();
    Proveedor GetById(int id);
    void Register(DTOProveedor model);
    void Update(int id, DTOProveedor model);
    void Delete(int id);
}

public class ServicioProveedor: IServicioProveedor
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioProveedor(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }



    public IEnumerable<Proveedor> GetAll()
    {
        return _context.Proveedoress;
    }

    public Proveedor GetById(int id)
    {
        return GetProveedor(id);
    }

    public void Register(DTOProveedor model)
    {
        // validate
        if (_context.Proveedoress.Any(x => x.Nombre == model.Nombre) && _context.Proveedoress.Any(x => x.Telefono == model.Telefono))
            throw new AppException("Producto '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<Proveedor>(model);

        // save user
        _context.Proveedoress.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOProveedor model)
    {
        var user = GetProveedor(id);

        // validate
        if (_context.Proveedoress.Any(x => x.Nombre == model.Nombre) && _context.Proveedoress.Any(x => x.Telefono == model.Telefono))
            throw new AppException("Proveedor '" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Proveedoress.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetProveedor(id);
        _context.Proveedoress.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private Proveedor GetProveedor(int id)
    {
        var user = _context.Proveedoress.Find(id);
        if (user == null) throw new KeyNotFoundException("Proveedor no encontrado");
        return user;
    }
}
