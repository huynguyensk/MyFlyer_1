using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MyFlyer.Web.ViewComponents
{
    public class LoginViewComponent :ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginViewComponent(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IViewComponentResult Invoke()
        {
            return View(User.Identity.IsAuthenticated);
        }
    }
}
