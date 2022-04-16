using Microsoft.EntityFrameworkCore;
using RentAThing.Models;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString(nameof(RentalContext)));
conStrBuilder.Password = builder.Configuration["RentalContext:Password"];
conStrBuilder.UserID = builder.Configuration["RentalContext:UserID"];
var connection = conStrBuilder.ConnectionString;

builder.Services.AddDbContext<RentalContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
} else
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services);
}

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
