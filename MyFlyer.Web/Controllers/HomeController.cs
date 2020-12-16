using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFlyer.Data.Interfaces;
using MyFlyer.Model.Entities;
using MyFlyer.Web.Models;
using MyFlyer.Web.Models.DataModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;

namespace MyFlyer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository, IMerchantRepository merchantRepository, ICartRepository cartRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _merchantRepository = merchantRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //var pros = _productRepository.GetAll();
            //var products = _mapper.Map<List<ProductViewModel>>(pros);
            //var merchs = _merchantRepository.GetAll();
            //var merchants = _mapper.Map<List<MerchantViewModel>>(merchs);
            //dynamic result = new ExpandoObject();
            //result.Products = products;
            //result.Merchants = merchants;
            //return View(result);
            return RedirectToAction("Index", "Product");
        }

       
        [HttpPost]
        public IActionResult AddtoCart(int Id, int quantity)
        {
            var pro = _productRepository.GetById(Id);
            var product = _mapper.Map<ProductViewModel>(pro);
            var cartItem = new CartItemViewModel
            {
                Product = product,
                Quantity = quantity
            };
            var cartView = new CartViewModel();
            cartView.CartItems.Add(cartItem);
            if (User.Identity.IsAuthenticated)
            {
                cartView.UserName = User.Identity.Name;
                var cart = _mapper.Map<Cart>(cartView);
                _cartRepository.Add(cart);
                
            }
            dynamic myCart = new ExpandoObject();
            myCart.Product = product;
            myCart.CartView = cartView;
            return View(myCart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
