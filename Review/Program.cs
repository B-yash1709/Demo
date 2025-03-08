using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using Review.Middleware;
//a;sldkjf;laskdjf

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure Database Connection
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection for Business & Repository Layers
builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();
builder.Services.AddScoped<IEmployeeRL, EmployeeRL>();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Exception Handling — Correct Order
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Detailed error page for development
}
else
{
    app.UseMiddleware<ExceptionMiddleware>(); // Custom middleware for production
}

// Enable routing for clarity (best practice)
app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthorization();

// Enable Swagger in all environments (for better visibility)
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
