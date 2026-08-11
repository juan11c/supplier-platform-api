using Microsoft.EntityFrameworkCore;
using SupplierPlatform.Application.Interfaces;
using SupplierPlatform.Application.Interfaces.Repositories;
using SupplierPlatform.Application.Services.Suppliers;
using SupplierPlatform.Infrastructure.Persistence;
using SupplierPlatform.Infrastructure.Persistence.Repositories;
using SupplierPlatform.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar Entity Framework Core con PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Inyección de dependencias de repositorios y servicios
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IClaimTokenGenerator, ClaimTokenGenerator>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();