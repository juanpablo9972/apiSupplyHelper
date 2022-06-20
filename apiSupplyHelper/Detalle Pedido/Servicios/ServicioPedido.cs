using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Detalle_Pedido.DTO;
using apiSupplyHelper.Detalle_Pedido.Modelos;
using apiSupplyHelper.Helpers;
using AutoMapper;

namespace apiSupplyHelper.Detalle_Pedido.Servicios;

public interface IServicioPedido
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Pedido> GetAll();
    Pedido GetById(int id);
    void Register(DTOPedido model);
    void Update(int id, DTOPedido model);
    void Delete(int id);
}
public class ServicioPedido: IServicioPedido
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioPedido(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }


    public IEnumerable<Pedido> GetAll()
    {
        return _context.Pedidos;
    }

    public Pedido GetById(int id)
    {
        return GetPedido(id);
    }

    public void Register(DTOPedido model)
    {
        // validate
      //  if (_context.Pedidos.Any(x => x.Nombre == model.Nombre) && _context.Pedidos.Any(x => x.Apellido == model.Apellido) && _context.Pedidos.Any(x => x.Telefono == model.Telefono))
        //    throw new AppException("Pedido '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<Pedido>(model);

        // save user
        _context.Pedidos.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOPedido model)
    {
        var user = GetPedido(id);

        // validate
       // if (model.Fecha != user.Nombre && _context.Pedidos.Any(x => x.Nombre == model.Nombre))
        //    throw new AppException("Pedido'" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Pedidos.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetPedido(id);
        _context.Pedidos.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private Pedido GetPedido(int id)
    {
        var user = _context.Pedidos.Find(id);
        if (user == null) throw new KeyNotFoundException("Pedido no encontrado");
        return user;
    }
}
