using TheDressVault;
using Dresses.Core.Repositories;
using Dresses.Core.Services;
using Dresses.Data;
using Dresses.Service;
using System.Text.Json.Serialization;
using Dresses.Core;

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