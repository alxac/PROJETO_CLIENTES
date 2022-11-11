using CrossCutting.DependencyInjection;
using Data.Implementations;
using Data.Models;
using Data.Repository;
using Domain.Interface;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Services;

;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ConfigureRepository.ConfigureDependenciesRepository(builder.Services);
//builder.Services.AddTransient<IClientesService, ClienteService>();
//builder.Services.AddTransient<IClienteEnderecosService, ClienteEnderecoService>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped<IClienteRepository, ClientesRepository>();
//builder.Services.AddScoped<IClienteEnderecosRepository, ClienteEnderecosRepository>();

////var conexao = "Data Source=SPBOX\\SQLEXPRESS;Initial Catalog=PBS_TESTE;Integrated Security=True;TrustServerCertificate=True";
//var conexao = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=PBS_TESTE;Integrated Security=True;TrustServerCertificate=True";
//builder.Services.AddDbContext<PBS_TESTEContext>(options => options.UseSqlServer(conexao));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
