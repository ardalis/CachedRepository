using CachedRepoSample.Data.Models;

namespace CachedRepoSample.Data
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}