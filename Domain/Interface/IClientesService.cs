using Domain.Entities;

namespace Domain.Interface
{
    public interface IClientesService : IBaseService<Clientes>
    {
        public Task<List<Clientes>> SelectAllDataAsync();
        public Task<Clientes> SelectByIdAsync(int id);
    }
}
