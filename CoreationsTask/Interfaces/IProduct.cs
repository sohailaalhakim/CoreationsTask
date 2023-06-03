using CoreationsTask.Data.Base;
using CoreationsTask.Models;

namespace CoreationsTask.Interfaces
{
    public interface IProduct : IEntityBaseRepository<Product>
    {
        public Task<List<Product>> GetCustomerProductAsync(int customerId);
    }
}
