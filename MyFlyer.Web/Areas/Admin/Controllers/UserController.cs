using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin, Staff")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }


        // GET: Admin/User
        public async Task<IActionResult> Index()
        {
            var userView = new List<UserViewModel>();
            var userDb = _userManager.Users;
            var roleDb = _roleManager.Roles;

            foreach (var user in userDb)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userV = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = new RoleViewModel { Name = roles[0] },
                    IsActive = user.IsActive
                };
                userView.Add(userV);
            }
            return View(userView);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var userDb = await _userManager.FindByIdAsync(Id.ToString());
            var roles = await _userManager.GetRolesAsync(userDb);
            var rolesDb = _roleManager.Roles;
            var rolesVdb = _mapper.Map<List<RoleViewModel>>(rolesDb);
            var userRoleDb = rolesDb.Where(r => r.Name == roles[0]);
            var roleVuser = _mapper.Map<List<RoleViewModel>>(userRoleDb);

            var userV = new UserViewModel
            {
                Id = Id,
                UserName = userDb.UserName,
                Email = userDb.Email,
                IsActive = userDb.IsActive,
                Role = new RoleViewModel
                {
                    Name = roles[0]
                }
            };
            dynamic model = new ExpandoObject();
            model.UserV = userV;
            model.RolesVlist = rolesVdb;
            model.RoleVuser = roleVuser[0];
            return View(model);
        }




        public IActionResult Role()
        {
            var roleDb = _roleManager.Roles;
            var roleView = new List<RoleViewModel>();
            foreach (var role in roleDb)
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
