using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.DetalleProveedor.DTO;
using apiSupplyHelper.DetalleProveedor.Modelos;
using apiSupplyHelper.Helpers;
using AutoMapper;

namespace apiSupplyHelper.DetalleProveedor.Servicios;

public interface IServicioServicioProveedor
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<ServicioProveedor> GetAll();
    ServicioProveedor GetById(int id);
    void Register(DTOServicioProveedor model);
    void Update(int id, DTOServicioProveedor model);
    void Delete(int id);
}

public class ServicioServicioProveedor: IServicioServicioProveedor
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioServicioProveedor(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }


    public IEnumerable<ServicioProveedor> GetAll()
    {
        return _context.ServicioProveedores;
    }

    public ServicioProveedor GetById(int id)
    {
        return GetServicioProveedor(id);
    }

    public void Register(DTOServicioProveedor model)
    {
        // validate
        //  if (_context.Agentes.Any(x => x.Nombre == model.Nombre) && _context.Agentes.Any(x => x.Apellido == model.Apellido) && _context.Agentes.Any(x => x.Telefono == model.Telefono))
        //    throw new AppException("Agente '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<ServicioProveedor>(model);

        // save user
        _context.ServicioProveedores.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOServicioProveedor model)
    {
        var user = GetServicioProveedor(id);

        // validate
        // if (model.Nombre != user.Nombre && _context.Agentes.Any(x => x.Nombre == model.Nombre))
        //   throw new AppException("Agente'" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.ServicioProveedores.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetServicioProveedor(id);
        _context.ServicioProveedores.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private ServicioProveedor GetServicioProveedor(int id)
    {
        var user = _context.ServicioProveedores.Find(id);
        if (user == null) throw new KeyNotFoundException("Detalle servicio proveedor no encontrado");
        return user;
    }
}
