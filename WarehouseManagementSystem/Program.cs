using Microsoft.EntityFrameworkCore;
using System.Net.Security;
using WarehouseManagementSystem.AL.services;
using WarehouseManagementSystem.DL.interfaces;
using WarehouseManagementSystem.IL.databases;
using WarehouseManagementSystem.PL.repository;
using WarehouseManagementSystem.PL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>();
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<ShipmentServiceAL>();

var app = builder.Build();
app.MapGrpcReflectionService();
// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<DataContext>();
	db.Database.Migrate();
}

app.MapGrpcService<ShipmentService>();

app.Run();
