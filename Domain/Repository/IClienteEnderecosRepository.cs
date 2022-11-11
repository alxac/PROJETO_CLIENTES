using Domain.Entities;
using Domain.Interface;

namespace Domain.Repository
{
    public interface IClienteEnderecosRepository : IRepository<ClienteEnderecos>
    {
        public Task<bool> DeleteByClientId(int id);
    }
}
