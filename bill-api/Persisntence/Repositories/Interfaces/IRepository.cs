
using bill_api.Domain.Entities;

namespace bill_api.Persisntace.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        Task Update(string id, T entity);
        Task Delete(string id);
    }
}

