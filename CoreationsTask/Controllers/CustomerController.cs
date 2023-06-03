using CoreationsTask.Interfaces;
using CoreationsTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CoreationsTask.Controllers
{
    
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerRepo;
        public CustomerController(CustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var allCustomers = await _customerRepo.GetAllAsync();

            return View(allCustomers);
        }

        public IActionResult Create()
        {
            return View();
        }

       

    }
}
