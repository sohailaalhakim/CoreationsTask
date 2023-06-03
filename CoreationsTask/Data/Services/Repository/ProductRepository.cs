using CoreationsTask.Models;
using CoreationsTask.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreationsTask.Data.Services.Repository
{
    public class ProductRepository : EntityBaseRepository<Product>, IProduct
    {
        private readonly ApplicationContext _dbContext;

        public ProductRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Product>> GetCustomerProductByIdAsync(int customerId)
        {
            return _dbContext.Products.Include(n => n.Customer).Where(p => p.CustomerId == customerId).ToListAsync();
        }

        public Task<List<Product>> GetAllCustomersProductsAsync()
        {
            return _dbContext.Products.Include(n => n.Customer).ToListAsync();
        }


    }
}
