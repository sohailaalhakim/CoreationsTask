using CoreationsTask.Data;
using CoreationsTask.Data.Base;
using CoreationsTask.Interfaces;
using CoreationsTask.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CoreationsTask.Repository
{
    public class CustomerRepository : EntityBaseRepository<Customer>, ICustomer
    {
        public CustomerRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
