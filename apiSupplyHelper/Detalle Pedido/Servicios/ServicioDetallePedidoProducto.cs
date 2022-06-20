using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Detalle_Pedido.DTO;
using apiSupplyHelper.Detalle_Pedido.Modelos;
using apiSupplyHelper.Helpers;
using AutoMapper;

namespace apiSupplyHelper.Detalle_Pedido.Servicios;

public interface IServicioDetallePedidoProducto
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<detallePedidoProducto> GetAll();
    detallePedidoProducto GetById(int id);
    void Register(DTODetallePedidoProducto model);
    void Update(int id, DTODetallePedidoProducto model);
    void Delete(int id);
}

public class ServicioDetallePedidoProducto: IServicioDetallePedidoProducto
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioDetallePedidoProducto(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }


    public IEnumerable<detallePedidoProducto> GetAll()
    {
        return _context.detallePedidoProductos;
    }

    public detallePedidoProducto GetById(int id)
    {
        return GetDetallePedidoProducto(id);
    }

    public void Register(DTODetallePedidoProducto model)
    {
        // validate
        //  if (_context.Agentes.Any(x => x.Nombre == model.Nombre) && _context.Agentes.Any(x => x.Apellido == model.Apellido) && _context.Agentes.Any(x => x.Telefono == model.Telefono))
        //    throw new AppException("Agente '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<detallePedidoProducto>(model);

        // save user
        _context.detallePedidoProductos.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTODetallePedidoProducto model)
    {
        var user = GetDetallePedidoProducto(id);

        // validate
        // if (model.Nombre != user.Nombre && _context.Agentes.Any(x => x.Nombre == model.Nombre))
        //   throw new AppException("Agente'" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.detallePedidoProductos.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetDetallePedidoProducto(id);
        _context.detallePedidoProductos.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private detallePedidoProducto GetDetallePedidoProducto(int id)
    {
        var user = _context.detallePedidoProductos.Find(id);
        if (user == null) throw new KeyNotFoundException("Detalle producto proveedor no encontrado");
        return user;
    }
}
