using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CoreationsTask.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationContext _context;
        public EntityBaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        //get all 
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        //add
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is error Saving the entity",ex.ToString());
            }
            return entity;
        }
        //delete
        public void Delete(int id)
        {
            try
            {
                var entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is error Deleting the entity", ex.ToString());

            }

        }


        //get by id
        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //update
        public Task<T> UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            throw new NotImplementedException();
        }


    }
}

