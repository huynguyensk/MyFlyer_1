using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using MyFlyer.Web.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFlyer.Web.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;

        public CategoryViewComponent(ICategoryRepository categoryRepository, IMerchantRepository merchantRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _merchantRepository = merchantRepository;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int? merchantViewModelId = null)
        {
            var result = GetCategoriesInMerchant(merchantViewModelId);
            return View(result);
        }
        public List<CategoryViewModel> GetCategoriesInMerchant(int? merchantId)
        {
            List<Category> categories = null;
            var mapped = new List<CategoryViewModel>();
            if (merchantId.HasValue)
            {
                var merchant = _merchantRepository.GetById(merchantId.Value);
                categories = _merchantRepository.GetCategoryInMerchant(merchant);
            }
            else
            {
                categories = _categoryRepository.GetAll();
            }
            mapped = _mapper.Map<List<CategoryViewModel>>(categories);
            return mapped;
        }
    }
}
