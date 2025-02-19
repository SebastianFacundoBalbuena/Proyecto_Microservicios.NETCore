
using Customer.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Customer.Services.Query;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CustomerServicesQuery>();
builder.Services.AddMediatR(Assembly.Load("Customer.Services.EventHandlers"));


builder.Services.AddDbContext<ApplicationDbContextCustomer>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
 x => x.MigrationsHistoryTable("_EFMigrationsHistory", "Customer")

 ));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
