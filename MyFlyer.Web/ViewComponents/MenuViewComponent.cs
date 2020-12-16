using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Web.Models.DataModel;

namespace MyFlyer.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        public MenuViewComponent(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var menus = _menuRepository.GetAll();
            var result = _mapper.Map<List<MenuViewModel>>(menus);
            return View(result);
        }
    }
}
