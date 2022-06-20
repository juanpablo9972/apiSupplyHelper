using apiSupplyHelper.Autorizacion;
using apiSupplyHelper.Categorias.Servicios;
using apiSupplyHelper.ContactoExterno.Servicios;
using apiSupplyHelper.Detalle_Pedido.Servicios;
using apiSupplyHelper.DetalleProveedor.Servicios;
using apiSupplyHelper.Helpers;
using apiSupplyHelper.Productos.Servicios;
using apiSupplyHelper.Proveedores.Servicios;
using apiSupplyHelper.Services;
using apiSupplyHelper.Servicios.Servicioss;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<DataContext>();
else
    builder.Services.AddDbContext<DataContext, SqliteDataContext>();

builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//DI

builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IServicioCategoriaProducto, ServicioCategoriaProducto>();
builder.Services.AddScoped<IServicioCategoriaServicio, ServicioCategoriaServicio>();
builder.Services.AddScoped<IServicioProducto, ServicioProducto >();
builder.Services.AddScoped<IServicioServicio, ServicioServicio>();
builder.Services.AddScoped<IServicioAgente, ServicioAgente>();
builder.Services.AddScoped<IServicioProveedor, ServicioProveedor>();
builder.Services.AddScoped<IServicioProductoProveedor, ServicioProductoProveedor>();
builder.Services.AddScoped<IServicioServicioProveedor, ServicioServicioProveedor>();
builder.Services.AddScoped<IServicioPedido, ServicioPedido>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run("https://localhost:4000");