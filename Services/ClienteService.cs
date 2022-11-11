using Domain.Entities;
using Domain.Interface;
using Domain.Repository;

namespace Services
{
    public class ClienteService : IClientesService
    {
        private IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Clientes>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Clientes> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Clientes> Post(Clientes clientes)
        {
            return await _repository.InsertAsync(clientes);
        }

        public async Task<Clientes> Put(Clientes clientes)
        {
            return await _repository.UpdateAsync(clientes);
        }

        public async Task<List<Clientes>> SelectAllDataAsync()
        {
            return await _repository.SelectAllDataAsync();
        }

        public async Task<Clientes> SelectByIdAsync(int id)
        {
            return await _repository.SelectByIdAsync(id);
        }
    }
}