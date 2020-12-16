using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFlyer.Data;
using MyFlyer.Model.Entities;
using MyFlyer.Web.Areas.Admin.Models;

namespace MyFlyer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: Admin/User
        public async Task<IActionResult> Index()
        {
            var userView = new List<AccountViewModel>();
            var userDb =  _userManager.Users;
            var roleDb = _roleManager.Roles;

            foreach (var user in userDb)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userV = new AccountViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = new RoleViewModel { Name = roles[0] },
                    IsActive = user.IsActive
                };
                userView.Add(userV);
            }
            return View(userView);
        }

        

        public IActionResult Role()
        {
            var roleDb = _roleManager.Roles;
            var roleView = new List<RoleViewModel>();
            foreach(var role in roleDb)
            {
                var roleV = new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name
                };
                roleView.Add(roleV);
            }
            return View(roleView);
        }
        

    }
}
