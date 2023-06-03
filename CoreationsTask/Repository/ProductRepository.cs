using CoreationsTask.Data;
using CoreationsTask.Data.Base;
using CoreationsTask.Interfaces;
using CoreationsTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreationsTask.Repository
{
    public class ProductRepository : EntityBaseRepository<Product>, IProduct
    {
        private readonly ApplicationContext _dbContext;

        public ProductRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Product>> GetCustomerProductAsync(int customerId)
        {
            return _dbContext.Products.Include(n=>n.Customer).Where(p => p.CustomerId == customerId).ToListAsync();
        }
    }
}
