using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using AutoMapper;
using Solution.API.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Que es dependecy injection? que es SOLID? SOLID son patrones de buenas practicas
//S:Cada metodo debe tener una sola responsabilidad
//O: Estoy abierto para extenderme pero cerrado para modificaciones, es riesgo modificar metodo existente
//L: Liskov es el principio de substitucion, se puede sustituir, como es el caso del repository
//I: 
//D:

builder.Services.AddDbContext<SolutionDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

//Cargar el perfil de AutoMapper en .NET Core 6
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
