using Catalog.Persistence.DataBase;
using Catalog.Service.Queries;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using Serilog;
using LoggerConfig;


var builder = WebApplication.CreateBuilder(args);

// Configura Serilog para enviar logs a Papertrail
var papertrailSettings = builder.Configuration.GetSection("Papertrail").Get<PapertrailSettings>();

// Configura el logger usando LoggerConfigg
LoggerConfigg.ConfigureLogger(papertrailSettings);

builder.Host.UseSerilog(); // Usar Serilog como proveedor de logging

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
 x=>x.MigrationsHistoryTable("_EFMigrationsHistory","Catalog")

 ));

builder.Services.AddScoped<ProductQueryService>();
builder.Services.AddScoped<ProductInStockQueryServices>();
builder.Services.AddMediatR(Assembly.Load("Catalog.Services.EventHandlers"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Iniciando la aplicación...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "La aplicación falló al iniciar.");
}
finally
{
    Log.CloseAndFlush();
}
