using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using prendasWebApi.Mappings;
using prendasWebApi.Models;
using prendasWebApi.Repositories;
using prendasWebApi.Repositories.IRepositories;
using prendasWebApi.Services;
using prendasWebApi.Services.Interfaz;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//REPOS-SERVICES
builder.Services.AddScoped<IPrendaRepository, PrendaRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
builder.Services.AddScoped<IRecuperatorioService, RecuperatorioService>();

//FLUENT
builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(MappingProfile));

//DBCONTEXT
builder.Services.AddDbContext<PrendasDbContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("prendasDB"));
});

var app = builder.Build();

//CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
