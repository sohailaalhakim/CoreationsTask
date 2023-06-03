using CoreationsTask.Data.Services.Interfaces;
using CoreationsTask.Data.Services.Repository;
using CoreationsTask.Models;
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _productRepo.GetAllAsync();

            return View(allProducts);
        }
        //--------------------------------------------------------
        //edit
        public async Task<IActionResult> Edit(int id)
        {
            Product productDetails = await _productRepo.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            Product productDetails = await _productRepo.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            if (ModelState.IsValid)
            {
                await _productRepo.UpdateAsync(id, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //--------------------------------------------------------------
        //delete
        public async Task<IActionResult> Delete(int id)
        {
            Product productDetails = await _productRepo.GetByIdAsync(id);

            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Product productDetails = await _productRepo.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            await _productRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        //-----------------------------------------------------------------------
        //add
        //public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {

            if (ModelState.IsValid)
            {
                await _productRepo.AddAsync(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }
    //---------------------------------------------------------------------
    //customer Product
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
