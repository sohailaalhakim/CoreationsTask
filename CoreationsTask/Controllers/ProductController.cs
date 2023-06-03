using CoreationsTask.Interfaces;
using CoreationsTask.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreationsTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productRepo;
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
            var allProducts = await _productRepo.GetCustomerProductAsync(customerId);
            return View(allProducts);
        }
    }
}
