using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.ContactoExterno.DTO;
using apiSupplyHelper.ContactoExterno.Modelos;
using apiSupplyHelper.Helpers;
using AutoMapper;

namespace apiSupplyHelper.ContactoExterno.Servicios;

public interface IServicioAgente
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Agente> GetAll();
    Agente GetById(int id);
    void Register(DTOAgente model);
    void Update(int id, DTOAgente model);
    void Delete(int id);
}

public class ServicioAgente: IServicioAgente
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioAgente(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }


    public IEnumerable<Agente> GetAll()
    {
        return _context.Agentes;
    }

    public Agente GetById(int id)
    {
        return GetAgente(id);
    }

    public void Register(DTOAgente model)
    {
        // validate
        if (_context.Agentes.Any(x => x.Nombre == model.Nombre) && _context.Agentes.Any(x => x.Apellido == model.Apellido) && _context.Agentes.Any(x => x.Telefono == model.Telefono))
            throw new AppException("Agente '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<Agente>(model);

        // save user
        _context.Agentes.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOAgente model)
    {
        var user = GetAgente(id);

        // validate
        if (model.Nombre != user.Nombre && _context.Agentes.Any(x => x.Nombre == model.Nombre))
            throw new AppException("Agente'" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Agentes.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetAgente(id);
        _context.Agentes.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private Agente GetAgente(int id)
    {
        var user = _context.Agentes.Find(id);
        if (user == null) throw new KeyNotFoundException("Agente no encontrado");
        return user;
    }
}
