using CoreationsTask.Data.Services.Interfaces;
using CoreationsTask.Data.Services.Repository;
using CoreationsTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {

            var allCustomers = await _customerRepo.GetAllAsync();
            //if not logged in 
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            return View(allCustomers);
        }
        [Authorize(Roles = "Admin")]

        //Get: customer/Create
        public IActionResult Create() => View();
      
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Customer Name,Mobile Phone,Address")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            await _customerRepo.AddAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        //edit get 
        public async Task<IActionResult> Edit(int id)
        {

            var customerDetails = await _customerRepo.GetByIdAsync(id);

            if (customerDetails == null) return View("NotFound");
            return View(customerDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Customer Name,Mobile Phone,Address")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            await _customerRepo.UpdateAsync(id, customer);
            return RedirectToAction("Index");

        }

    }
}
