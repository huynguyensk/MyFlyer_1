using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MyFlyer.Web.Models.Account;
using Microsoft.AspNetCore.Authorization;
using MyFlyer.Model.Entities;

namespace MyFlyer.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            AppUser user = null;
            var hasher = new PasswordHasher<IdentityUser>();
            if (loginViewModel.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(loginViewModel.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(loginViewModel.UsernameOrEmail);
            }
            if (user != null)
            {
                if (user.PasswordHash == hasher.HashPassword(null, loginViewModel.Password))
                {
                    isAuthenticate = true;
                    var roles = await _userManager.GetRolesAsync(user);
                    identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,roles.FirstOrDefault())
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("IncorrectInput", "Invalid Username or Password");
                return View(loginViewModel);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = new AppUser
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.UserName
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                return await LoginAsync(new LoginViewModel
                {
                    UsernameOrEmail = registerViewModel.UserName,
                    Password = registerViewModel.Password
                });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(registerViewModel);
        }
    }
}