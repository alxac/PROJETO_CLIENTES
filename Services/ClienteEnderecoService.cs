using Domain.Entities;
using Domain.Interface;
using Domain.Repository;

namespace Services
{
    public class ClienteEnderecoService : IClienteEnderecosService
    {
        private IClienteEnderecosRepository _repository;

        public ClienteEnderecoService(IClienteEnderecosRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ClienteEnderecos>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ClienteEnderecos> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> DeleteByClientId(int id)
        {
            return await _repository.DeleteByClientId(id);
        }

        public async Task<ClienteEnderecos> Post(ClienteEnderecos clientes)
        {
            return await _repository.InsertAsync(clientes);
        }

        public async Task<ClienteEnderecos> Put(ClienteEnderecos clientes)
        {
            return await _repository.UpdateAsync(clientes);
        }
    }
}