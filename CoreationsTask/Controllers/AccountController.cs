
using CoreationsTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreationsTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly ApplicationContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signinManager,
            ApplicationContext context )
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }


        //------Register---------
        public IActionResult Register()=> View();
      
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationVM newAccount)
        {
            var userCheckEmail = await _userManager.FindByEmailAsync(newAccount.Email);
            if (userCheckEmail != null)
            {
                ModelState.AddModelError("", "This email address already exists");
                return View(newAccount);

            }
            if (ModelState.IsValid)
            {
                //map from vm to model
                var user = new ApplicationUser()
                {
                    FullName = newAccount.FullName,
                    Email = newAccount.Email,
                    UserName = newAccount.UserName
                };

                //save to database and create cookie 
                IdentityResult result = await _userManager.CreateAsync(user, newAccount.Password);
                if (result.Succeeded)
                {
                    //create cookie using signinManager
                    await _userManager.AddToRoleAsync(user, UserRoles.User);
                    return RedirectToAction("RegisterCompleted", "Account");

                }
                else
                {
                    //add error
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
           return View(newAccount);
        }

        public IActionResult RegisterCompleted() => View();
       
        //--------LogIn---------------
        public IActionResult Login() => View();
       
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginUser.Email);
                if (user != null)
                {
                    var result = await _signinManager.PasswordSignInAsync(user, loginUser.Password, loginUser.RemeberMe,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid username and password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                }
            }
            return View(loginUser);
        }

        //--------LogOut---------------
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        //--------auth--------------
        public IActionResult AccessDenied(string ReturnUrl) => View();
        public IActionResult NotFound(string ReturnUrl) => View();


    }
}
