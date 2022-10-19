using Microsoft.EntityFrameworkCore;
using TestCrudService.Api.Common.Configs;
using TestCrudService.Api.Common.Interfaces;
using TestCrudService.Api.Dal;
using TestCrudService.Api.Dal.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DatabaseConfig dbConfig = builder.Configuration.GetSection("Database")
    .Get<DatabaseConfig>();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TestDbContext>(o =>
    o.UseSqlServer(connection));

builder.Services.AddScoped<ITestRepository, TestRepository>();

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