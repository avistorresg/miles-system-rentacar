using Microsoft.EntityFrameworkCore;
using MilesRentaCar.DataModel.Context;
using MilesRentaCar.Interfaces;
using MilesRentaCar.Services;

var builder = WebApplication.CreateBuilder(args);

//Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<MilesRentaCarContext>(delegate (DbContextOptionsBuilder context)
{
    context.UseSqlServer(configuration.GetConnectionString("MilesRentaCarConnection"));

});

//Se establece la inyeccion de dependencia de los servicios con sus interfaces
builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<IMarketService, MarketService>();
builder.Services.AddTransient<IClientService, ClientService>();

var app = builder.Build();

// Configuración de la canalización de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
