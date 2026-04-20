using TheDressVault;
using Dresses.Core.Repositories;
using Dresses.Core.Services;
using Dresses.Data;
using Dresses.Service;
using System.Text.Json.Serialization;
using Dresses.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IDressService, DressService>();
builder.Services.AddScoped<IDressRepository, DressRepository>();
builder.Services.AddAutoMapper(typeof(Mappingprofile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseShabbat();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate(); 
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataContext>(); // או MyDbContext
        context.Database.Migrate(); // פקודה זו בודקת את החיבור ומריצה שינויים
    }
    catch (Exception ex)
    {

    }
}

app.Run();

builder.Configuration.AddJsonFile("appsettings.secrets.json",
                                 optional: true,
                                 reloadOnChange: true);

var managerName = builder.Configuration["SystemSettings:ManagerUserName"];

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyManager", policy =>
        policy.RequireUserName(managerName));
});