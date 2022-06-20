using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Helpers;
using apiSupplyHelper.Servicios.DTO;
using apiSupplyHelper.Servicios.Modelos;
using AutoMapper;

namespace apiSupplyHelper.Servicios.Servicioss;
public interface IServicioServicio
{
    // AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<Serviciosss> GetAll();
    Serviciosss GetById(int id);
    void Register(DTOServicio model);
    void Update(int id, DTOServicio model);
    void Delete(int id);
}
public class ServicioServicio: IServicioServicio
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public ServicioServicio(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public IEnumerable<Serviciosss> GetAll()
    {
        return _context.Servicess;
    }

    public Serviciosss GetById(int id)
    {
        return GetServicio(id);
    }

    public void Register(DTOServicio model)
    {
        // validate
        if (_context.Servicess.Any(x => x.Nombre == model.Nombre))
            throw new AppException("Servicio '" + model.Nombre + "' ya existe");

        // map model to new user object
        var user = _mapper.Map<Serviciosss>(model);

        // save user
        _context.Servicess.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, DTOServicio model)
    {
        var user = GetServicio(id);

        // validate
        if (model.Nombre != user.Nombre && _context.Servicess.Any(x => x.Nombre == model.Nombre))
            throw new AppException("Servicio '" + model.Nombre + "' ya existe");

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Servicess.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetServicio(id);
        _context.Servicess.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private Serviciosss GetServicio(int id)
    {
        var user = _context.Servicess.Find(id);
        if (user == null) throw new KeyNotFoundException("Servicio no encontrado");
        return user;
    }
}
