using CoreationsTask.Interfaces;
using CoreationsTask.Models;
using CoreationsTask.Repository;
using CoreationsTask.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreationsTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductController(ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _productRepo.GetAllAsync();

            return View(allProducts);
        }
        public async Task<IActionResult> CustomerProduct(int customerId)
        {
           
            var allProducts = await _productRepo.GetCustomerProductByIdAsync(customerId);
            return View(allProducts);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllCustomersProducts()
        {
            var allProducts = await _productRepo.GetAllCustomersProductsAsync();
            return View(allProducts);
        }


    }
}
