using Domain.Entities;

namespace Domain.Interface
{
    public interface IClienteEnderecosService : IBaseService<ClienteEnderecos>
    {
        public Task<bool> DeleteByClientId(int id);
    }
}
