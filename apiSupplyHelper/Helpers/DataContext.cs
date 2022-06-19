using apiSupplyHelper.Categorias.Modelos;
using apiSupplyHelper.Data.Models.Auth;
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
}