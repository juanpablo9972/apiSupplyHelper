using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Categorias.DTO;
using apiSupplyHelper.Categorias.Modelos;
using apiSupplyHelper.Helpers;
using AutoMapper;

namespace apiSupplyHelper.Categorias.Servicios
{
    public interface IServicioCategoriaServicio
    {
        // AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<CategoriaServicio> GetAll();
        CategoriaServicio GetById(int id);
        void Register(DTOCategoriaServicio model);
        void Update(int id, DTOCategoriaServicio model);
        void Delete(int id);
    }

    public class ServicioCategoriaServicio: IServicioCategoriaServicio
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public ServicioCategoriaServicio(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }



        public IEnumerable<CategoriaServicio> GetAll()
        {
            return _context.CategoriaServicios;
        }

        public CategoriaServicio GetById(int id)
        {
            return GetCategoriaServicio(id);
        }

        public void Register(DTOCategoriaServicio model)
        {
            // validate
            if (_context.CategoriaServicios.Any(x => x.Nombre == model.Nombre))
                throw new AppException("Categoria de Servicio '" + model.Nombre + "' ya existe");

            // map model to new user object
            var user = _mapper.Map<CategoriaServicio>(model);

            // save user
            _context.CategoriaServicios.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, DTOCategoriaServicio model)
        {
            var user = GetCategoriaServicio(id);

            // validate
            if (model.Nombre != user.Nombre && _context.CategoriaServicios.Any(x => x.Nombre == model.Nombre))
                throw new AppException("Nombre '" + model.Nombre + "' ya existe");

            // copy model to user and save
            _mapper.Map(model, user);
            _context.CategoriaServicios.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetCategoriaServicio(id);
            _context.CategoriaServicios.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private CategoriaServicio GetCategoriaServicio(int id)
        {
            var user = _context.CategoriaServicios.Find(id);
            if (user == null) throw new KeyNotFoundException("Categoria de Servicios no encontrada");
            return user;
        }
    }
}
