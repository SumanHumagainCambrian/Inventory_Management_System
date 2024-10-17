using Microsoft.EntityFrameworkCore;
using Inventory_Management_System.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the InventoryMSDbContext with the dependency injection system.
builder.Services.AddDbContext<InventoryMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable Swagger/OpenAPI documentation for development and testing purposes.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger in development mode to visualize API documentation.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensure the app uses HTTPS redirection (for security) and authorization.
app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers to the endpoints, allowing API routes to be accessed.
app.MapControllers();

app.Run();
