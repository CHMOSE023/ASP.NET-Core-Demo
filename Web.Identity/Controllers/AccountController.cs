using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Identity.ViewsModels;

namespace Web.Identity.Controllers
{
    public class AccountController:Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser>   _userManager;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager=signInManager;
            _userManager=userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user= await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {

                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.PassWorld, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            ModelState.AddModelError("", "用户名/密码不正确");
            return View(loginViewModel);
        }


        public IActionResult Register()
        {
            return View() ; 
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModels registerViewModels)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = registerViewModels.UserName
                };

                var result =await _userManager.CreateAsync(user,registerViewModels.PassWorld);

                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            return View(registerViewModels);
        }

        [HttpPost]  
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
