using System.Linq.Expressions;

namespace CoreationsTask.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class, IEntityBase, new()
    {
         Task<IEnumerable<T>> GetAllAsync();
         Task<T> GetByIdAsync(int id);
         Task<T> AddAsync(T entity);
         Task UpdateAsync(int id, T entity);
         Task DeleteAsync(int id);
        bool isExist(int id);
    }
}
