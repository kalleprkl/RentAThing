using RentAThing.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<RentalContext>(opt =>
    opt.UseInMemoryDatabase("RentAThing"));

var app = builder.Build();

app.Run();
