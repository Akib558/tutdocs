using Microsoft.EntityFrameworkCore;
using Tutdocs.Data.Context;
using Tutdocs.Repository.Implementation;
using Tutdocs.Repository.Interface;
using Tutdocs.Service.Implementation;
using Tutdocs.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers(); // <-- IMPORTANT!
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // <-- THIS IS MISSING!

app.Run();