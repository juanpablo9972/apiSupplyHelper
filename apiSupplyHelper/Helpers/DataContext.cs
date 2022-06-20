using apiSupplyHelper.Categorias.Modelos;
using apiSupplyHelper.Data.Models.Auth;
using apiSupplyHelper.Productos.Modelos;
using apiSupplyHelper.Servicios.Modelos;
using Microsoft.EntityFrameworkCore;

namespace apiSupplyHelper.Helpers;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server database
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<CategoriaProducto> CategoriaProductos { get; set; }
    public DbSet<CategoriaServicio> CategoriaServicios { get; set; }
    public DbSet<Producto> Products { get; set; }
    public DbSet<Serviciosss> Servicess { get; set; }

}