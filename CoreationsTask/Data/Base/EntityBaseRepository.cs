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
           
             await _context.Set<T>().AddAsync(entity);
             await _context.SaveChangesAsync();
   
            return entity;
        }
        //delete
       
        public async Task DeleteAsync(int id)
        {
            
           var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
           EntityEntry entityEntry = _context.Entry<T>(entity);
           entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }


        //get by id
        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        //update
        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
          
        }

        public bool isExist(int id)
        {
            throw new NotImplementedException();
        }


    }
}

