using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TestCrudService.Common.Configs;
using TestCrudService.Common.Interfaces;
using TestCrudService.DAL;
using TestCrudService.DAL.Repositories;
using TestCrudService.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(i =>
    {
        i.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        i.JsonSerializerOptions.WriteIndented = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DatabaseConfig dbConfig = builder.Configuration.GetSection("Database")
    .Get<DatabaseConfig>();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TestDbContext>(o =>
    o.UseSqlServer(connection));

builder.Services.AddScoped<ICrudRepository, CrudRepository>();
builder.Services.AddScoped<ICrudService, CrudService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();