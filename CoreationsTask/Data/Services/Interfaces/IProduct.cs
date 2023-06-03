using CoreationsTask.Models;

namespace CoreationsTask.Data.Services.Interfaces
{
    public interface IProduct : IEntityBaseRepository<Product>
    {
        public Task<List<Product>> GetCustomerProductByIdAsync(int customerId);
        public Task<List<Product>> GetAllCustomersProductsAsync();

    }
}
