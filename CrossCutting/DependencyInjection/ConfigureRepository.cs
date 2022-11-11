using Data.Implementations;
using Data.Models;
using Data.Repository;
using Domain.Interface;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClientesService, ClienteService>();
            serviceCollection.AddTransient<IClienteEnderecosService, ClienteEnderecoService>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IClienteRepository, ClientesRepository>();
            serviceCollection.AddScoped<IClienteEnderecosRepository, ClienteEnderecosRepository>();

            var conexao = "Data Source=SPBOX\\SQLEXPRESS;Initial Catalog=PBS_TESTE;Integrated Security=True;TrustServerCertificate=True";
            //var conexao = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=PBS_TESTE;Integrated Security=True;TrustServerCertificate=True";
            serviceCollection.AddDbContext<PBS_TESTEContext>(options => options.UseSqlServer(conexao));

        }
    }
}
