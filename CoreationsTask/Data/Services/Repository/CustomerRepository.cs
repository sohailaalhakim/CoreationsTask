using CoreationsTask.Data.Services.Interfaces;
using CoreationsTask.Models;


namespace CoreationsTask.Data.Services.Repository
{
    public class CustomerRepository : EntityBaseRepository<Customer>, ICustomer
    {
        public CustomerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
