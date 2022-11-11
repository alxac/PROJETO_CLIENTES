using Data.Models;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class ClientesRepository : BaseRepository<Clientes>, IClienteRepository
    {
        private DbSet<Clientes> _dataset;

        public ClientesRepository(PBS_TESTEContext context) : base(context)
        {
            _dataset = context.Set<Clientes>();
        }

        public async Task<List<Clientes>> SelectAllDataAsync()
        {
            return await _dataset.Include(c => c.ClienteEnderecos).ToListAsync();
        }

        public async Task<Clientes> SelectByIdAsync(int id)
        {
            return await _dataset
                .Include(c => c.ClienteEnderecos)
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}
