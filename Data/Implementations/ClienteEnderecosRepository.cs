using Data.Models;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class ClienteEnderecosRepository : BaseRepository<ClienteEnderecos>, IClienteEnderecosRepository
    {
        private DbSet<ClienteEnderecos> _datasetEnd;

        public ClienteEnderecosRepository(PBS_TESTEContext context) : base(context)
        {
            _datasetEnd = context.Set<ClienteEnderecos>();
        }

        public async Task<bool> DeleteByClientId(int id)
        {
            List<ClienteEnderecos> enderecos = await _datasetEnd.Where(e => e.IdCliente == id).ToListAsync();
            if (enderecos != null)
            {
                foreach (var item in enderecos)
                {
                    var teste = DeleteAsync(item.Id).Result;
                }
                return true;
            }
            return false;
        }
    }
}
