using Domain.Entities;

namespace Domain.Interface
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<bool> Delete(int id);
    }
}
