using MagnetronAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MagnetonContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MagnetronContext"));
});

// CORS Configuration
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
