using System.Linq.Expressions;

namespace CoreationsTask.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class, IEntityBase, new()
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(int id, T entity);
        public void Delete(int id);
        public bool isExist(int id);
    }
}
