using Domain.Entities;
using Domain.Interface;

namespace Domain.Repository
{
    public interface IClienteRepository : IRepository<Clientes>
    {
        public Task<List<Clientes>> SelectAllDataAsync();
        public Task<Clientes> SelectByIdAsync(int id);
    }
}
