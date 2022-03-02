using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<VehicleContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("VehicleDatabase")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var vehicleContext = services.GetRequiredService<VehicleContext>();
    vehicleContext.Database.Migrate();
    //Only seed the database if in development, mocked data have no place in production.
    if (app.Environment.IsDevelopment())
    {
        DbInitializer.Seed(vehicleContext);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
