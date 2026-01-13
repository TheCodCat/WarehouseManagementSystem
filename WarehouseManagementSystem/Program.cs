using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;
using WarehouseManagementSystem.AL.Dtos;
using WarehouseManagementSystem.AL.services;
using WarehouseManagementSystem.DL.interfaces;
using WarehouseManagementSystem.IL.databases;
using WarehouseManagementSystem.PL.repository;
using WarehouseManagementSystem.PL.Services;
using WarehouseManagementSystemServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>();
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ShipmentServiceAL>();
builder.Services.AddScoped<ProductServiceAL>();

TypeAdapterConfig<ProductDto, Product>
	.NewConfig()
	.ConstructUsing(srs => new Product()
	{
		Id = srs.Id,
		Name = srs.Name,
		Description = srs.Description
	});

TypeAdapterConfig<ShipmentRequest, ShipmentDto>
	.NewConfig()
	.ConstructUsing(src => new ShipmentDto()
	{
		DateTime = DateTime.UtcNow,
		Id = 0,
	});

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
app.MapGrpcService<ProductorService>();

app.Run();
