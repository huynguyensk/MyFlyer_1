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
using System.Collections.Generic;

namespace MyFlyer.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            if (loginViewModel.Email.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            }
            else
            {
                user = await _userManager.FindByNameAsync(loginViewModel.Email);
            }
            if (user != null)
            {
                await _signInManager.SignOutAsync();

                var result = await _signInManager.PasswordSignInAsync(user, "123", false, false);
                if (result.Succeeded)
                { 
                    isAuthenticate = true;
                    var roles = await _userManager.GetRolesAsync(user);
                    var claim1 = new Claim(ClaimTypes.Name, user.UserName);
                    var claim2 = new Claim(ClaimTypes.Role, roles.FirstOrDefault());
                    List<Claim> claim = new List<Claim> { claim1, claim2 };
                    identity = new ClaimsIdentity(claim,CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                if (principal.IsInRole("Admin"))
                {                    
                    return RedirectToAction("Create", "Flyer", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
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
                UserName = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                IdentityResult roleResult;
                var roleCheck = await _roleManager.RoleExistsAsync("Admin");
                if (!roleCheck)
                {
                    var newRole = new AppRole
                    {
                        Name = "User"
                    };
                    roleResult = await _roleManager.CreateAsync(newRole);
                }
                await _userManager.AddToRoleAsync(user, "Admin");
                return await LoginAsync(new LoginViewModel
                {
                    Email = registerViewModel.Email,
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