using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using MyFlyer.Web.Models.DataModel;
using MyFlyer.Web.Util;

namespace MyFlyer.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMerchantCategoryRepo _merchantCategoryRepo;
        private readonly IMapper _mapper;

        public ProductController(IMerchantRepository merchantRepository, ICategoryRepository categoryRepository, IProductRepository productRepository, IMerchantCategoryRepo merchantCategoryRepo, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _merchantCategoryRepo = merchantCategoryRepo;
            _mapper = mapper;
        }
        
        public IActionResult Index(int ? merchId, int ?cateId, int ? id, string search=null, int pageSize =18, int pageNo = 1)
        {
            var merchants = new List<Merchant>();
            var categories = new List<Category>();
            var products = new List<Product>();
            if (search != null)
            {
                search = search.ToLower();
                merchants = _merchantRepository.GetAll();
                products = _productRepository.GetByCondition(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search));
            }
            else
            {
                if ((!merchId.HasValue && !cateId.HasValue && !id.HasValue))
                {
                    merchants = _merchantRepository.GetAll();
                    products = _productRepository.GetAll();
                }
                else if (merchId.HasValue && (!cateId.HasValue) && (!id.HasValue))
                {
                    var merchant = _merchantRepository.GetById(merchId.Value);
                    merchants.Add(merchant);
                    foreach (var item in _merchantCategoryRepo.GetCategoriesInMerchant(merchant))
                    {
                        var cate = _categoryRepository.GetById(item);
                        categories.Add(cate);//categories contain products
                    }
                    products = _productRepository.GetProductInMerchant(merchId.Value);
                }
                else if (merchId.HasValue && cateId.HasValue && (!id.HasValue))
                {
                    var merchant = _merchantRepository.GetById(merchId.Value);
                    merchants.Add(merchant);
                    foreach (var item in _merchantCategoryRepo.GetCategoriesInMerchant(merchant))
                    {
                        var cate = _categoryRepository.GetById(item);
                        if (cate.Products != null)
                        {
                            categories.Add(cate); //all category doesn't contain any product
                        }
                    }
                    products = _productRepository.GetProductInCategory(cateId.Value);

                }
                else if (merchId.HasValue && cateId.HasValue && id.HasValue)
                {
                    return RedirectToAction("Details", id.Value);
                }
            }
            
            categories = categories.Where(c => c.Products!=null).ToList();
            categories.OrderByDescending(c => c.Products.Count);
            var merchantsView = _mapper.Map<List<MerchantViewModel>>(merchants);
            var categoriesView = _mapper.Map<List<CategoryViewModel>>(categories);
            var productsView = _mapper.Map<List<ProductViewModel>>(products);
            var pages = PagingList<ProductViewModel>.Create(productsView, pageNo, pageSize);
            dynamic model = new ExpandoObject();
            model.Merchants = merchantsView;
            model.Categories = categoriesView;
            model.Products = productsView;
            model.PageList = pages;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var merchants = _merchantRepository.GetAll();
            var product = _productRepository.GetById(id);
            var productView = _mapper.Map<ProductViewModel>(product);
            var merchantsView = _mapper.Map<List<MerchantViewModel>>(merchants);
            dynamic model = new ExpandoObject();
            model.Product = productView;
            model.Merchants = merchantsView;
            return View(model);
        }

      
    }
}